using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeySequence : MonoBehaviour
    {
        private List<Key> mKeys = new List<Key>();

        [SerializeField] private KeyPrefabs mKeyPrefabs;

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                var childTransform = transform.GetChild(i);
                var key = childTransform.GetComponent<Key>();
                if (key != null) mKeys.Add(key);
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
    }
}
