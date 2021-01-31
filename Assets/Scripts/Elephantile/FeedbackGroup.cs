using UnityEngine;

namespace Elephantile
{
    public class FeedbackGroup : MonoBehaviour
    {
        [SerializeField] private SimpleAnimation mHappyAnimation;
        [SerializeField] private SimpleAnimation mSadAnimation;

        private int mNextHappyFrame;
        private int mNextSadAnimation;
        
        public void PlayHappyFace()
        {
            mSadAnimation.gameObject.SetActive(false);
            mHappyAnimation.gameObject.SetActive(true);
            
            mHappyAnimation.PlayFrame(mNextHappyFrame);
            mNextHappyFrame = (mNextHappyFrame + 1) % 2;
        }

        public void PlaySadFace()
        {
            mHappyAnimation.gameObject.SetActive(false);
            mSadAnimation.gameObject.SetActive(true);
            
            mSadAnimation.PlayFrame(mNextSadAnimation);
            mNextSadAnimation = (mNextSadAnimation + 1) % 2;
        }

        public void Reset()
        {
            mHappyAnimation.gameObject.SetActive(false);
            mSadAnimation.gameObject.SetActive(false);
        }
    }
}