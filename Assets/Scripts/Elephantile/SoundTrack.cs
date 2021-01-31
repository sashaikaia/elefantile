using UnityEngine;
using FMOD;
using FMODUnity;

namespace Elephantile
{
    public class SoundTrack : MonoBehaviour
    {
        private StudioEventEmitter mEmitter;
        private bool mStartedPlaying = false;

        private void Awake()
        {
            mEmitter = GetComponent<StudioEventEmitter>();
        }

        public void PlayCorrectNote()
        {
            if (!mStartedPlaying)
            {
                mEmitter.Play();
                mStartedPlaying = true;
            }
            else
            {
                mEmitter.EventInstance.triggerCue();
            }
        }

        public void ResetTrack()
        {
            mStartedPlaying = false;
        }
    }
}