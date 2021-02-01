using System;
using System.Collections;
using UnityEngine;
using FMOD;
using FMODUnity;
using UnityEngine.UI;
using Debug = FMOD.Debug;

namespace Elephantile
{
    public class PayoffScreenBase : MonoBehaviour
    {
        [SerializeField] private StudioEventEmitter mEventEmitter;
        [SerializeField] private string mNextLevel;
        [SerializeField] private Text mPressAnyKeyToContinue;
        [SerializeField] private LevelLoader mLevelLoader;
        private bool mAllowTransitionLevel;
        
        private void Awake()
        {
        }

        public virtual void Play()
        {
            IEnumerator DoPlay()
            {
                yield return new WaitForSeconds(6.0f);
                DisplayNextLevelHint();
            }
            StartCoroutine(DoPlay());

        }

        private void DisplayNextLevelHint()
        {
            mPressAnyKeyToContinue.gameObject.SetActive(true);
            mAllowTransitionLevel = true;
        }

        private void Update()
        {
            if (mAllowTransitionLevel && Input.anyKeyDown)
            {
                mLevelLoader.LoadLevel(mNextLevel);
            }
        }
    }
}