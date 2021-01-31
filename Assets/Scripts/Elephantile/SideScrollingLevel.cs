﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Elephantile
{
    public class SideScrollingLevel : LevelBase
    {
        public string levelText = "";

        [SerializeField] private NoteSubmitter mNoteSubmitter;
        
        [FormerlySerializedAs("mNotViewPrefab")] [SerializeField]
        private NoteView mNoteViewPrefab;

        private LevelDefinition mLevelData;
        private LevelState mLevelState = LevelState.Intro;
        private BufferedInput<int> mQweInput = new BufferedInput<int>();
        private bool mAcceptingInput = true;

        private List<List<NoteDefinition>> mCandidateDefinitions = new List<List<NoteDefinition>>();

        private Transform mCandidatesParent;
        private List<List<NoteView>> mCandidateViews = new List<List<NoteView>>();
        private int mNextColumnIndex = 0;

        private void Awake()
        {
            mLevelData = mNoteDb.ParseLevel(levelText);
            GenerateCandidates();
            CreateCandidateGameObjects();
            StartCoroutine(CrtRunLevel());
        }

        private void GenerateCandidates()
        {
            foreach (var correct in mLevelData)
            {
                var column = mNoteDb
                    .notes
                    .Where(n => n.pitch != correct.pitch).ToList();

                column.Shuffle();
                column.Backfill(2);
                column.RemoveExcess(2);
                column.Add(correct);
                column.Shuffle();

                mCandidateDefinitions.Add(column);
            }
        }

        private void CreateCandidateGameObjects()
        {
            int colId = 0;
            var parent = new GameObject("candidates_parent");
            mCandidatesParent = parent.transform;
            parent.transform.localPosition = Vector3.zero;

            foreach (var column in mCandidateDefinitions)
            {
                Debug.Assert(column.Count == 3);
                var columnView = new List<NoteView>();
                for (var i = 0; i < 3; ++i)
                {
                    var noteViewPos = new Vector2(colId, i - 1.0f);
                    var noteView = Instantiate(mNoteViewPrefab, parent.transform);
                    noteView.transform.localPosition = noteViewPos;
                    noteView.SetNote(column[i]);
                    columnView.Add(noteView);
                }

                mCandidateViews.Add(columnView);
                ++colId;
            }
        }

        public override LevelDefinition GetDefinition() => mLevelData;

        private IEnumerator CrtRunLevel()
        {
            mLevelState = LevelState.Game;
            yield break;
        }

        private void Update()
        {
            if (mLevelState == LevelState.Game)
            {
                ReadQweInput();
                if (mAcceptingInput) ProcessQweInput();
            }
        }

        private void ProcessQweInput()
        {
            var maybeKey = mQweInput.ReadKey();
            if (maybeKey is null) return;

            Debug.Log("Submitting note to submitter");

            var currentColumn = mCandidateDefinitions[mNextColumnIndex];
            var chosenNote = currentColumn[maybeKey.Value];
            var currentSong = 0; // CHANGE ME LATER TO UPDATE AFTER EACH CHAPTER
            mNoteSubmitter.SubmitNote(chosenNote.pitch, currentSong);
            
            foreach (var noteView in mCandidateViews[mNextColumnIndex])
            {
                noteView.Fade();
            }

            ++mNextColumnIndex;
            StartCoroutine(CrtDoMoveLeft());
        }

        private IEnumerator CrtDoMoveLeft()
        {
            var x = mCandidatesParent.localPosition.x;
            mAcceptingInput = false;
            yield return mCandidatesParent.DOLocalMoveX(x - 1.0f, 0.2f).WaitForCompletion();
            mAcceptingInput = true;
        }

        private void ReadQweInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                mQweInput.SetKey(2);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                mQweInput.SetKey(1);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                mQweInput.SetKey(0);
            }
        }

        private void UpdateIntro()
        {
        }


        private enum LevelState
        {
            Intro,
            Game,
            Payoff
        }
    }
}