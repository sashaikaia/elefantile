using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSubmitter : MonoBehaviour
{
    private char mNextChar;
    public void SubmitNote(char n) {
        if (mNextChar == n) {

        } else {
            onError();
        }
    }

    private void onError() {
        Debug.Log("wrong note");
    }
}
