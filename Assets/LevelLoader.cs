using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        //The scene will transition to the next level
        if (Input.GetKeyDown("space"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));

    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //play scene animation
        transition.SetTrigger("Start");

        //wait for animation to finish
        yield return new WaitForSeconds(transitionTime);

        //loads the scene
        SceneManager.LoadScene(levelIndex);

    }
}
