using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

// initializes and maps char to note sound clips
// assign order A-G
public class NotePlayer : MonoBehaviour
{
    [SerializeField] private List<FMODUnity.StudioEventEmitter> mNoteList;
    [SerializeField] private StudioEventEmitter mWrongSoundEmitter;
    
    private Dictionary<char, FMODUnity.StudioEventEmitter> mNoteMapper;

    // private const int mMaxNumNotes = 7;
    public void Awake()
    {
        mNoteMapper = new Dictionary<char, FMODUnity.StudioEventEmitter>();
        for (int i = 0; i < mNoteList.Count; ++i)
        {
            // hacky bad coding, but it assigns A-G to indices 0-end...
            // will need to change if using black keys
            mNoteMapper.Add((char) ('A' + i), mNoteList[i]);
        }
    }

    public void PlayNote(char n)
    {
        if (!mNoteMapper.ContainsKey(n))
        {
            Debug.LogError($"The note '{n}' is not mapped");
            return;
        }
        mNoteMapper[n].GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }

    public void PlayFailureSound()
    {
        mWrongSoundEmitter.Play();
    }
}