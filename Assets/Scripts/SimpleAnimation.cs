using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimation : MonoBehaviour
{
    [SerializeField] private List<GameObject> mFrames = new List<GameObject>();
    [SerializeField] private float mInterval;
    [SerializeField] private bool mShouldPlayAtStart;
    [SerializeField] private int mFrameAtStart = 0;

    private int mCurrentFrame = 0;
    private void Awake()
    {
        mCurrentFrame = mFrameAtStart;
        PlayFrame(mFrameAtStart);
        if (mShouldPlayAtStart) Play();
    }

    public void PlayFrame(int frame)
    {
        mFrames[mCurrentFrame].SetActive(false);
        mFrames[frame].SetActive(true);
        mCurrentFrame = frame;
    }

    public void Play()
    {
        IEnumerator DoPlay()
        {
            while (true)
            {
                yield return new WaitForSeconds(mInterval);
                PlayFrame((mCurrentFrame + 1) % mFrames.Count);
            }
        }

        StartCoroutine(DoPlay());
    }
}