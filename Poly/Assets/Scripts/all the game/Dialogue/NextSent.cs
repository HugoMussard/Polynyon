using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E))
           FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
