using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    string piano = "piano_anim";
    string keyW = "keyW_anim";
    string keyS = "keyS_anim";
    string keyX = "keyX_anim";
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
            anim.Play(piano);
            anim.Play(keyW);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play(piano);
            anim.Play(keyS);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            anim.Play(piano);
            anim.Play(keyX);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.Play(piano);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.Play(piano);
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.Play(piano);
        }
    }
}
