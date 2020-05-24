using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialog()
    {
        Debug.Log("debuttrig");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }


}
