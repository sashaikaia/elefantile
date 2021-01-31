using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    [SerializeField] string stateName;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadQweInput();
    }
    private void ReadQweInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.Play(stateName);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play(stateName);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            anim.Play(stateName);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.Play(stateName);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.Play(stateName);
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.Play(stateName);
        }
    }
}
