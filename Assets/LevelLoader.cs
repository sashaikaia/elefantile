using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Elephantile;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public Animator title;
    public float transitionTime = 1f;
    
    private bool mPreventLoadNewScene = false;
    [SerializeField] private Image mCrossFade;
    [SerializeField] private SoundTrack mSoundTrack;
    
    // public void LoadNextLevel()
    // {
    //     StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    // }

    private void Start()
    {
        var color = mCrossFade.color;
        color.a = 0.0f;
        mCrossFade.DOColor(color, transitionTime);
    }

    IEnumerator CrtLoadLevel(string name)
    {
        if (mPreventLoadNewScene) yield break;
        mPreventLoadNewScene = true;

        var color = mCrossFade.color;
        color.a = 1.0f;
        yield return mCrossFade.DOColor(color, transitionTime).WaitForCompletion();
        
        //play scene animation
        // transition.SetTrigger("Start");

        //wait for animation to finish
        yield return new WaitForSeconds(transitionTime);

        //loads the scene
        SceneManager.LoadScene(name);
        mPreventLoadNewScene = false;
    }

    public void LoadLevel(string sceneName)
    {
        if (mSoundTrack != null)
        {
            mSoundTrack.Stop();
        }
        StartCoroutine(CrtLoadLevel(sceneName));
    }
}
