using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Elephantile
{
    public class NoteView : MonoBehaviour
    {
        private SpriteRenderer mSpriteRenderer;
        [SerializeField] private KeyHintView mKeyHintView;
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
            return transform.DOPunchScale(Vector3.one * factor, duration, 1);
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

        public void ShowKeyHint(char hint)
        {
            
        }

        public void HideKeyHint()
        {
            
        }

        public void UnFade(float duration = 0.2f)
        {
            var color = mSpriteRenderer.color;
            color.a = 1.0f;
            mSpriteRenderer.DOColor(color, duration);
        }
    }

    public class KeyHintView : MonoBehaviour
    {
        
    }
}