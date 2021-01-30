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

    // Staging area
    [SerializeField] private StageArea mStageArea;

    // Empty track prefab
    [SerializeField] private KeyTrack mTrackPrefab;

    // The index range of the tracks. By default from -1 to 1.
    // These corresponds to the y-value of the track gameObjects.
    public int mTrackRangeMin;
    public int mTrackRangeMax;

    public bool mProgressionStarted;

    private void Awake()
    {
        StartCoroutine(CrtRunGame());
        GenerateCandidateTracks();
    }

    private IEnumerator CrtRunGame()
    {
        const int maxKeysPerRow = 4;
        (mStageArea.mTracks, mStageArea.mTracksParent) = GenerateCorrectTrack(maxKeysPerRow);
        yield return StartCoroutine(mStageArea.CrtDisplayAllCorrectPatterns());
    }

    private (List<KeyTrack>, Transform) GenerateCorrectTrack(int maxKeysPerRow)
    {
        var result = new List<KeyTrack>();

        var rowId = 0;
        var colId = 0;
        var trackParent = new GameObject("track_parent");

        trackParent.transform.SetParent(mStageArea.transform, false);
        trackParent.transform.localPosition = Vector3.zero;

        var targetTrack = CreateEmptyTrack(trackParent.transform);
        targetTrack.transform.SetLocalY(-rowId);

        for (var keyIndex = 0; keyIndex < numCorrectKeys; ++keyIndex)
        {
            if (colId >= maxKeysPerRow)
            {
                ++rowId;
                colId -= maxKeysPerRow;
                result.Add(targetTrack);
                targetTrack.AlignKeys(-1.5f, 1.0f);
                
                targetTrack = CreateEmptyTrack(trackParent.transform);
                targetTrack.transform.SetLocalY(-rowId);
            }

            var rand = Random.Range(0, mKeyPrefabs.Count);
            var prefab = mKeyPrefabs[rand];
            var key = Instantiate(prefab, targetTrack.transform);

            targetTrack.Add(key);
            ++colId;
        }

        return (result, trackParent.transform);
    }

    private KeyTrack CreateEmptyTrack(Transform parent)
    {
        return Instantiate(mTrackPrefab, parent);
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