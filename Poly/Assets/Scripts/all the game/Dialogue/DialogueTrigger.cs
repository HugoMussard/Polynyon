using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private Dialogue dial; 

    public int nb_indices;

    public DialogueManager script;
    

    private void Start()
    {
        dial = new Dialogue();
    }


    public void TriggerDialog()
    {
        if (script.first_done)
        {
            dial.sentences = new string[dialogue.sentences.Length - nb_indices];
            for (int i = 0; i < dialogue.sentences.Length - nb_indices; i++)
            {
                dial.sentences[i] = dialogue.sentences[nb_indices + i]; 
            }
        }
        else
        {
            dial.sentences = new string[nb_indices];
            for (int j = 0; j < nb_indices; j++)
            {
                dial.sentences[j] = dialogue.sentences[j]; 
            }
        }
        if (!script.started) FindObjectOfType<DialogueManager>().StartDialogue(dial);
    }


}
