using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text FenDial;

    private Queue<string> Sentences;
    // Start is called before the first frame update
    void Start()
    {
        Sentences = new Queue<string>();
        Debug.Log("Debut");
        
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Cursor.lockState = CursorLockMode.None;
        Sentences.Clear();
        
        Debug.Log("StartDial");
        foreach (string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }


        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        FenDial.text = "test";
        
        if (Sentences.Count == 0)
        {
            EndDialogue();
        }

        string kestuvadire = Sentences.Dequeue();

        
        StopAllCoroutines();
        StartCoroutine(typesent(kestuvadire));
    }

    IEnumerator typesent(string sentence)
    {
        FenDial.text = "";

        Debug.Log(sentence);
        foreach (var letter in sentence.ToCharArray())
        {
            FenDial.text += letter;
            
            yield return new WaitForSeconds(0.01f);
        }

    }

    public void EndDialogue()
    {
        FindObjectOfType<Hiel>().isfinished = true;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
