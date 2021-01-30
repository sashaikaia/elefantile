using System;
using DG.Tweening;
using UnityEngine;

public class Key : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;
    public bool mDeactivated = false;
    public int mIndexInSequence;
    
    private void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Deactivate()
    {
        if (mDeactivated) return;
        var endColor = mSpriteRenderer.color;
        endColor.a = 0.2f;
        mSpriteRenderer.DOColor(endColor, 0.2f);
        mDeactivated = true;
    }
}