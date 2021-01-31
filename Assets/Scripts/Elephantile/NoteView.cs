using System;
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

        public void SetNote(NoteDefinition note)
        {
            mSpriteRenderer.sprite = note.sprite;
            mSpriteRenderer.color = note.color;
        }
    }
}