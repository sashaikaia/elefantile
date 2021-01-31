using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeToShape : MonoBehaviour
{

    [SerializeField]
    Transform currentSetOfThree;

    [SerializeField]
    string correctItemName;

    [SerializeField]
    Material outlineMaterial;

    [SerializeField]
    GameObject particles;


    SpriteRenderer sr;
    GameObject targetGO;

    Sprite originalPlayerSprite;
    Vector3 originalPlayerPosition;
    Material defaultSpriteMaterial;

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalPlayerSprite = sr.sprite;
        originalPlayerPosition = transform.position;
        defaultSpriteMaterial = sr.material;

    }

    void Update()
    {
        targetGO = null;
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetGO = currentSetOfThree.transform.GetChild(0).gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            targetGO = currentSetOfThree.transform.GetChild(1).gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            targetGO = currentSetOfThree.transform.GetChild(2).gameObject;
        }
        if (targetGO != null)
        {
            sr.sprite = targetGO.GetComponent<SpriteRenderer>().sprite;
            StartCoroutine(ShowNoteFeedback(targetGO.transform,
                                            targetGO.name == correctItemName
                ));
            StartCoroutine(MovePlayerY(targetGO.transform.position.y));

            targetGO.GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reset());
        }
        
        
    }

    public IEnumerator ShowNoteFeedback(Transform targetNote, bool isCorrect)
    {
        if (isCorrect)
        {
            particles.SetActive(true);
            targetNote.GetComponent<SpriteRenderer>().material = outlineMaterial;
        }
        foreach(Transform t in currentSetOfThree)
        {
            if (t != targetNote)
            {
                t.gameObject.GetComponent<Renderer>().material.DOFade(0f, 0.25f);
            }
        }
        yield return new WaitForSeconds(0.5f);
        yield return currentSetOfThree.DOLocalMoveX(transform.position.x, 0.75f).WaitForCompletion();
    }

    public IEnumerator MovePlayerY(float targetY)
    {
        yield return transform.DOLocalMoveY(targetY, 0.25f).WaitForCompletion();
    }



    public IEnumerator Reset()
    {
        sr.sprite = originalPlayerSprite;
        sr.color = Color.white;
        transform.position = originalPlayerPosition;
        foreach (Transform t in currentSetOfThree)
        {
            t.gameObject.GetComponent<Renderer>().material = defaultSpriteMaterial;
            t.gameObject.GetComponent<Renderer>().material.DOFade(1f, 0.01f);
        }
        yield return currentSetOfThree.DOLocalMoveX(1.5f, 0.01f).WaitForCompletion();
    }

}
