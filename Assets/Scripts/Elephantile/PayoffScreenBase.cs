using UnityEngine;
using FMOD;
using FMODUnity;

namespace Elephantile
{
    public class PayoffScreenBase : MonoBehaviour
    {
        public virtual void Play()
        {
            GetComponent<StudioEventEmitter>().Play();

            for (int i = 0; i < 100; ++i)
            {
                GetComponent<StudioEventEmitter>().EventInstance.triggerCue();
            }
        }
    }
}