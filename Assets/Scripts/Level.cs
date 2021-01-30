using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    public float bpm;
        
    // Tracks
    public List<KeyTrack> keyTracks = new List<KeyTrack>();
    public KeyTrack correctTrack;
    public int numCorrectKeys;
    
    // The key prefab set to select from
    [SerializeField] private KeyPrefabs mKeyPrefabs;
    
    // The index range of the tracks. By default from -1 to 1.
    // These corresponds to the y-value of the track gameObjects.
    public int mTrackRangeMin;
    public int mTrackRangeMax;

    public bool mProgressionStarted;
    
    private void Awake()
    {
        GenerateCorrectTrack();
    }

    private void GenerateCorrectTrack()
    {
        for (var keyIndex = 0; keyIndex < numCorrectKeys; ++keyIndex)
        {
            var rand = Random.Range(0, mKeyPrefabs.Count);
            var prefab = mKeyPrefabs[rand];
            var key = Instantiate(prefab, correctTrack.transform);
            key.transform.localPosition = Vector3.right * (keyIndex - 2);
            correctTrack.Add(key);
        }
    }

    public void StartProgression()
    {
        if (mProgressionStarted) return;
        mProgressionStarted = true;

        foreach (var correctKey in correctTrack)
        {
            var spriteRenderer = correctKey.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) continue;
            var color = spriteRenderer.color;
            color.a = 0.0f;
            spriteRenderer.DOColor(color, 0.2f);
        }
    }
}
