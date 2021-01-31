using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    [SerializeField] private List<FMODUnity.StudioEventEmitter> mNoteList;
    private Dictionary<char, FMODUnity.StudioEventEmitter> mNoteMapper;
    // private const int mMaxNumNotes = 7;
    void Awake() {
        mNoteMapper = new Dictionary<char, FMODUnity.StudioEventEmitter>();
        for (int i = 0; i < mNoteList.Count; ++i) {
            mNoteMapper.Add((char)('A'+i), mNoteList[i]);
        }
    }
}
