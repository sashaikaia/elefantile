using System.Collections.Generic;
using UnityEngine;

public class KeyPrefabs : ScriptableObject
{
    [SerializeField] private List<Key> mPrefabs;

    public Key GetKey(int index)
    {
        return mPrefabs[index];
    }
}