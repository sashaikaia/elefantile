using UnityEngine;

namespace Elephantile
{
    public class BufferedInput
    {
        private KeyCode? mKey;
        private float mDeadBy;

        public void SetKey(KeyCode key, float life = 0.1f)
        {
            mKey = key;
            mDeadBy = Time.time + life;
        }

        public KeyCode? ReadKey()
        {
            if (Time.time >= mDeadBy) mKey = null;
            var ret = mKey;
            mKey = null;
            return ret;
        }
    }
}