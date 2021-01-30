using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeyTrack : MonoBehaviour, IList<Key>
    {
        private List<Key> mKeys = new List<Key>();

        [SerializeField] private KeyPrefabs mKeyPrefabs;

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                var childTransform = transform.GetChild(i);
                var key = childTransform.GetComponent<Key>();
                if (key == null) continue;
                mKeys.Add(key);
                key.mIndexInSequence = i;
            }

            AlignKeys();
        }

        private void AlignKeys()
        {
            for (int i = 0; i < mKeys.Count; ++i)
            {
                var key = mKeys[i];
                key.transform.localPosition = Vector3.right * i;
            }
        }

        #region Interface implementation

        public IEnumerator<Key> GetEnumerator()
        {
            return mKeys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) mKeys).GetEnumerator();
        }

        public void Add(Key item)
        {
            mKeys.Add(item);
        }

        public void Clear()
        {
            mKeys.Clear();
        }

        public bool Contains(Key item)
        {
            return mKeys.Contains(item);
        }

        public void CopyTo(Key[] array, int arrayIndex)
        {
            mKeys.CopyTo(array, arrayIndex);
        }

        public bool Remove(Key item)
        {
            return mKeys.Remove(item);
        }

        public int Count => mKeys.Count;

        public bool IsReadOnly => ((ICollection<Key>) mKeys).IsReadOnly;

        public int IndexOf(Key item)
        {
            return mKeys.IndexOf(item);
        }

        public void Insert(int index, Key item)
        {
            mKeys.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            mKeys.RemoveAt(index);
        }

        public Key this[int index]
        {
            get => mKeys[index];
            set => mKeys[index] = value;
        }

        #endregion
    }
}