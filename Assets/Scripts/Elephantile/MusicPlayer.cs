using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// initializes and maps char to note sound clips
// assign order A-G
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private List<FMODUnity.StudioEventEmitter> mSongList;
    private List<bool> mStart; // list of status on which songs have been started
    // private Dictionary<char, FMODUnity.StudioEventEmitter> mNoteMapper;
    
    // private const int mMaxNumNotes = 7;
    public void Awake() {
        mStart = new List<bool>();
        for (int i = 0; i < mSongList.Count; ++i) {
            mStart.Add(false);
        }
    }

    // public void PlayNote(char n) {
    //     mNoteMapper[n].GetComponent<FMODUnity.StudioEventEmitter>().Play();
    // }

    public void PlayNote(int songIndex) {
        if (mStart[songIndex]) {
            mSongList[songIndex].GetComponent<FMODUnity.StudioEventEmitter>().Play();
            mStart[songIndex] = false;
        } else {
            mSongList[songIndex].GetComponent<FMODUnity.StudioEventEmitter>().EventInstance.triggerCue();
        }
    }
}
