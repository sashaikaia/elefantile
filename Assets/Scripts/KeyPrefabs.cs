using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Key Prefabs")]
public class KeyPrefabs : ScriptableObject, IReadOnlyList<Key>
{
    [SerializeField] private List<Key> mPrefabs;

    public IEnumerator<Key> GetEnumerator()
    {
        return mPrefabs.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => mPrefabs.Count;

    public Key this[int index] => mPrefabs[index];
}