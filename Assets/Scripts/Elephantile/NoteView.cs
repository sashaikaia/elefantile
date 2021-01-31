using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Elephantile
{
    public class NoteView : MonoBehaviour
    {
        private SpriteRenderer mSpriteRenderer;

        private void Awake()
        {
            mSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Fade(float targetAlpha = 0.2f, float duration = 0.2f)
        {
            var color = mSpriteRenderer.color;
            color.a = targetAlpha;
            mSpriteRenderer.DOColor(color, duration);
        }

        public Tweener PunchScale(float factor = 1.05f, float duration = 0.2f)
        {
            return transform.DOPunchScale(Vector3.one * factor, duration);
        }
        
        public Tweener PunchScale(Vector3 factor, float duration = 0.2f)
        {
            return transform.DOPunchScale(factor, duration);
        }
        
        public void SetNote(NoteDefinition note)
        {
            mSpriteRenderer.sprite = note.sprite;
            mSpriteRenderer.color = note.color;
        }
    }
}