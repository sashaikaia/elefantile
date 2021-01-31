using Elephantile;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Karaoke : MonoBehaviour
{
    private List<List<Note>> notes = new List<List<Note>>();
    public float mInterval;
    [SerializeField] private int maxRows;
    [SerializeField] NoteView mNoteViewPrefab;
    [SerializeField] Transform mRootTransform;
    [SerializeField] private NotePlayer mNotePlayer;

    private struct Note
    {
        public NoteDefinition definition;
        public NoteView noteView;
    }

    public IEnumerator DoKaraoke(LevelDefinition level)
    {
        LoadCorrectResult(level);

        for (int rowId = 0; rowId < notes.Count; ++rowId)
        {
            var row = notes[rowId];
            var y = mRootTransform.localPosition.y;
            y += 1.0f;

            foreach (var note in row)
            {
                yield return note.noteView.PunchScale(1.005f).WaitForCompletion();
                mNotePlayer.PlayNote(note.definition.pitch);
                yield return new WaitForSeconds(0.5f);
            }

            if (rowId < notes.Count - 1)
                yield return mRootTransform.DOLocalMoveY(y, 0.2f).WaitForCompletion();
        }

        yield return new WaitForSeconds(mInterval);
    }

    public void LoadCorrectResult(LevelDefinition level)
    {
        var rowId = 0;
        var colId = 0;
        var targetTrack = new List<Note>();

        void CommitTarget()
        {
            ++rowId;
            colId = 0;
            notes.Add(targetTrack);
            targetTrack = new List<Note>();
        }

        foreach (var correctKey in level)
        {
            var tempNote = new Note {definition = correctKey, noteView = noteViewFor(correctKey, rowId, colId)};
            targetTrack.Add(tempNote);
            ++colId;
            if (colId >= maxRows)
            {
                CommitTarget();
            }
        }

        if (colId > 0) CommitTarget();
    }

    private NoteView noteViewFor(NoteDefinition definition, int rowId, int colId)
    {
        var view = Instantiate(mNoteViewPrefab, mRootTransform);
        Vector2 position = new Vector2(colId - 3, -rowId);
        view.transform.localPosition = position;
        view.SetNote(definition);
        return view;
    }
}