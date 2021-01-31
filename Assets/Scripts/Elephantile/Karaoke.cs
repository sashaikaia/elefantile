using Elephantile;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Karaoke : MonoBehaviour
{
    private List<List<Note>> mNotes = new List<List<Note>>();
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

        for (int rowId = 0; rowId < mNotes.Count; ++rowId)
        {
            var row = mNotes[rowId];
            var y = mRootTransform.localPosition.y;
            y += 1.0f;

            foreach (var note in row)
            {
                yield return note.noteView.PunchScale(1.005f, 0.1f).WaitForCompletion();
                mNotePlayer.PlayNote(note.definition.pitch);
                yield return new WaitForSeconds(0.5f);
            }

            if (rowId < mNotes.Count - 1)
                yield return mRootTransform.DOLocalMoveY(y, 0.2f).WaitForCompletion();
        }

        yield return new WaitForSeconds(mInterval);
    }

    public void LoadCorrectResult(LevelDefinition level)
    {
        var rowId = 0;
        foreach (var phrase in level.Phrases)
        {
            var colId = 0;
            var currentRow = new List<Note>();
            foreach (var noteDef in phrase)
            {
                var tempNote = new Note {definition = noteDef, noteView = NoteViewFor(noteDef, rowId, colId)};
                currentRow.Add(tempNote);
                ++colId;
            }

            mNotes.Add(currentRow);
            ++rowId;
        }
    }

    private NoteView NoteViewFor(NoteDefinition definition, int rowId, int colId)
    {
        var view = Instantiate(mNoteViewPrefab, mRootTransform);
        Vector2 position = new Vector2(colId, -rowId);
        view.transform.localPosition = position;
        view.SetNote(definition);
        return view;
    }
}