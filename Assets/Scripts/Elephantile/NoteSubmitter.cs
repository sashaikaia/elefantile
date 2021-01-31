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
        [SerializeField] private NotePlayer mNotePlayer;
        public void Awake() {
            mLevelDef = mLevelBase.GetDefinition();
            mLevelDefIndex = 0;
        }
        public void SubmitNote(char n) {
            if (true) { //mLevelDef[mLevelDefIndex].pitch == n) {
                mNotePlayer.PlayNote(0); // CHANGE ME LATER
            } else {
                onError();
            }
        }

        private void onError() {
            Debug.Log("wrong note");
        }
    }
}