using System.Collections.Generic;
using UnityEngine;

namespace Elephantile
{
    public class HealthMeter : MonoBehaviour
    {
        [SerializeField] private List<SimpleAnimation> mHealthBars;

        public void SetHealth(int health)
        {
            for (var i = 0; i < health; ++i)
            {
                mHealthBars[i].PlayFrame(0);
            }

            for (var i = health; i < mHealthBars.Count; ++i)
            {
                mHealthBars[i].PlayFrame(1);
            }
        }
    }
}