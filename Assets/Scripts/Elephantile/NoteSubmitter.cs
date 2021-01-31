using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elephantile {
    public class NoteSubmitter : MonoBehaviour
    {
        private char mNextChar;
        // "read only" definition of the correct notes
        private LevelDefinition mLevelDef;
        private int mLevelDefIndex;
        [SerializeField] private LevelBase mLevelBase;
        [SerializeField] private MusicPlayer mNotePlayer;
        public void Awake() {
            mLevelDef = mLevelBase.GetDefinition();
            mLevelDefIndex = 0;
        }
        public void SubmitNote(char n, int songIndex) {
            // TODO: mLevelDefIndex needs to jump +3, or mLevelDef needs to contain only the capital letters
            if (mLevelDef[mLevelDefIndex].pitch == n) {
                mNotePlayer.PlayNote(songIndex);
            } else {
                onError();
            }
        }

        private void onError() {
            Debug.Log("wrong note");
            // TODO: somehow needs to skip FMOD's current cue/sustain point
        }
    }
}