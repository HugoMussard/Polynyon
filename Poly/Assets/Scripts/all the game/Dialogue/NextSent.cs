using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSent : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && GetComponent<DialogueManager>().started && GetComponent<Hiel>().check)
           FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
