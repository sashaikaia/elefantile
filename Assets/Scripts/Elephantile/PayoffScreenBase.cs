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
        private void Awake()
        {
        }

        public virtual void Play()
        {
            IEnumerator DoPlay()
            {
                print("LOAD NEXT LEVEL HERE!");
                yield return new WaitForSeconds(6.0f);
                DisplayNextLevelHint();
            }
            StartCoroutine(DoPlay());

        }

        private void DisplayNextLevelHint()
        {
            mPressAnyKeyToContinue.gameObject.SetActive(true);
        }
    }
}