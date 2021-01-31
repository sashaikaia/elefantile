using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// initializes and maps char to note sound clips
// assign order A-G
public class NotePlayer : MonoBehaviour
{
    [SerializeField] private List<FMODUnity.StudioEventEmitter> mNoteList;
    private Dictionary<char, FMODUnity.StudioEventEmitter> mNoteMapper;
    // private const int mMaxNumNotes = 7;
    public void Awake() {
        mNoteMapper = new Dictionary<char, FMODUnity.StudioEventEmitter>();
        for (int i = 0; i < mNoteList.Count; ++i) {
            mNoteMapper.Add((char)('A'+i), mNoteList[i]);
        }
    }

    public void PlayNote(char n) {
        mNoteMapper[n].GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
