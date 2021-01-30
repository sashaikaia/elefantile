using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    public float bpm;

    // Tracks
    [FormerlySerializedAs("keyTracks")] public List<KeyTrack> candidateTracks = new List<KeyTrack>();
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
        GenerateCandidateTracks();
    }

    private void GenerateCorrectTrack()
    {
        for (var keyIndex = 0; keyIndex < numCorrectKeys; ++keyIndex)
        {
            var rand = Random.Range(0, mKeyPrefabs.Count);
            var prefab = mKeyPrefabs[rand];
            var key = Instantiate(prefab, correctTrack.transform);

            // Destroy the collider so we do not collide with the correct keys...
            Destroy(key.GetComponent<Collider2D>());

            // Record the prefab so we can generate it later
            key.prototype = prefab;

            correctTrack.Add(key);
        }
        correctTrack.AlignKeys(-2.0f);
    }

    private void GenerateCandidateTracks()
    {
        var numTracks = mTrackRangeMax - mTrackRangeMin + 1;

        // Align the y-coordinates of the tracks
        for (var trackIndex = mTrackRangeMin; trackIndex <= mTrackRangeMax; ++trackIndex)
        {
            var indexInList = trackIndex - mTrackRangeMin;
            var track = candidateTracks[indexInList];

            var position = track.transform.localPosition;
            position.y = trackIndex;
            track.transform.localPosition = position;
        }

        foreach (var correctKey in correctTrack)
        {
            var candidateKeys = mKeyPrefabs.Where(key => key != correctKey.prototype).ToList();
            
            candidateKeys.Backfill(numTracks - 1);
            candidateKeys.RemoveExcess(numTracks - 1);
            candidateKeys.Add(correctKey.prototype);
            candidateKeys.Shuffle();
            
            for (int i = 0; i < numTracks; ++i)
            {
                var track = candidateTracks[i];
                var prefab = candidateKeys[i];
                var key = Instantiate(prefab, track.transform);
                track.Add(key);
            }
        }

        foreach (var candidateTrack in candidateTracks)
        {
            candidateTrack.AlignKeys(0f, 1.6f);
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