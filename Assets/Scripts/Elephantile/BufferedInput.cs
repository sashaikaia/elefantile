using UnityEngine;

namespace Elephantile
{
    public class BufferedInput<T> where T : struct
    {
        private T? mKey;
        private float mDeadBy;

        public void SetKey(T key, float life = 0.1f)
        {
            mKey = key;
            mDeadBy = Time.time + life;
        }

        public T? ReadKey()
        {
            if (Time.time >= mDeadBy) mKey = null;
            var ret = mKey;
            mKey = null;
            return ret;
        }
    }
}