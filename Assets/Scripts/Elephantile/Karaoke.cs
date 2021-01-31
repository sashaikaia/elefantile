using Elephantile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karaoke : MonoBehaviour
{
    private List<List<Note>> notes = new List<List<Note>>();
    public float mInterval;
    [SerializeField] private int maxRows;
    [SerializeField] NoteView mNoteViewPrefab;
    [SerializeField] Transform mRootTransform;

    struct Note
    {
        public NoteDefinition definition;
        public NoteView noteView;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator doKaraoke()
    {
        yield return new WaitForSeconds(mInterval);


    }
    public void LoadCorrectResult(LevelDefinition level)
    {

        var rowId = 0;
        var colId = 0;
        var trackParent = new GameObject("track_parent");
        var targetTrack = new List<Note>();
        foreach (var correctKey in level)
        {

            var tempNote = new Note {definition = correctKey, noteView = noteViewFor(correctKey, rowId, colId)};
            targetTrack.Add(tempNote);
            ++colId;
            if (colId >= maxRows)
            {
                ++rowId;
                colId = 0;
                notes.Add(targetTrack);
                targetTrack = new List<Note>();
            }
        }

    }
    private NoteView noteViewFor(NoteDefinition definition, int rowId, int colId)
    { 
        var view = Instantiate(mNoteViewPrefab, mRootTransform);
        Vector2 position = new Vector2(colId, -rowId);
        view.transform.localPosition = position;

        return view;
    }
}
