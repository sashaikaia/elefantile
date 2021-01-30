using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class StageArea : MonoBehaviour
{
    [SerializeField] private float mInterval;

    public List<KeyTrack> mTracks;
    public Transform mTracksParent;
    
    public IEnumerator CrtDisplayAllCorrectPatterns()
    {
        var (tracks, tracksParent) = (mTracks, mTracksParent);

        foreach (var track in tracks)
        {
            yield return new WaitForSeconds(mInterval);
            var position = tracksParent.transform.localPosition;
            var targetY = position.y + 1.0f;
            yield return tracksParent.DOLocalMoveY(targetY, 0.25f).WaitForCompletion();
        }
        
        yield return new WaitForSeconds(mInterval);
    }
}