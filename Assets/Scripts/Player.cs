using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<KeyTrack> mTracks;
    [SerializeField] private Level level;
    [SerializeField] private float mTrackTransitionSpeed;
    private int mTrackTransitionDirection;
    private int mCurrentTrack;

    private void Awake()
    {
        mTracks = level.candidateTracks;
    }

    private void Update()
    {
        transform.localPosition += Vector3.right * (level.bpm * Time.deltaTime);
        if (!level.mProgressionStarted && transform.localPosition.x >= 6.0f)
        {
            level.StartProgression();
        }

        if (level.mProgressionStarted)
        {
            HandleTrackTransition();
        }
    }

    private void HandleTrackTransition()
    {
        if (mTrackTransitionDirection != 0)
        {
            // The player is transitioning tracks
            var currentPosition = transform.position;
            var targetTrack = mCurrentTrack + mTrackTransitionDirection;
            var progress = Mathf.Abs(currentPosition.y - mCurrentTrack);
            
            if (progress >= Mathf.Abs(mTrackTransitionDirection - 0.01f))
            {
                // The player has already made to the target track
                
                // Snap to target track and update current tracker
                currentPosition.y = targetTrack;
                mCurrentTrack = targetTrack;
                transform.position = currentPosition;
                
                // End the transition
                mTrackTransitionDirection = 0;
            }
            else
            {
                transform.position += mTrackTransitionDirection * mTrackTransitionSpeed * Time.deltaTime * Vector3.up;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                mTrackTransitionDirection = 1;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                mTrackTransitionDirection = -1;
            }
            
            // Ignore out-of-range tracks
            var targetTrack = mCurrentTrack + mTrackTransitionDirection;
            if (targetTrack > level.mTrackRangeMax || targetTrack < level.mTrackRangeMin)
            {
                mTrackTransitionDirection = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var key = other.gameObject.GetComponent<Key>();
        if (key == null || key.mDeactivated) return;

        var keyIndex = key.mIndexInSequence;
        foreach (var track in mTracks)
        {
            if (keyIndex >= track.Count) continue;
            track[keyIndex].Deactivate();
        }
    }
}