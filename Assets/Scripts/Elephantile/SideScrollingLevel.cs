using System;
using System.Collections;
using UnityEngine;

namespace Elephantile
{
    public class SideScrollingLevel : LevelBase
    {
        public string levelText = "";

        [SerializeField] private NoteDb mNoteDb;
        private LevelDefinition mLevelData;
        private LevelState mLevelState = LevelState.Intro;
        private BufferedInput mQweInput;
        
        private void Awake()
        {
            mLevelData = mNoteDb.ParseLevel(levelText);
            StartCoroutine(CrtRunLevel());
        }

        private IEnumerator CrtRunLevel()
        {
            mLevelState = LevelState.Game;
            
            yield break;
        }

        private void Update()
        {
            if (mLevelState == LevelState.Game)
            {
                
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