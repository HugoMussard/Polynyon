using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text FenDial;

    private Queue<string> Sentences;

    public bool started; 
    
    public GameObject mur;

    public bool first_done; 
    
    void Start()
    {
        mur.SetActive(false);
        Sentences = new Queue<string>();
        Debug.Log("Debut");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Cursor.lockState = CursorLockMode.None;
        Sentences.Clear();
        mur.SetActive(true);
        Debug.Log("StartDial");
        foreach (string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            string kestuvadire = Sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(typesent(kestuvadire));
        }
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
        if (!started) started = true;
        if (!first_done) first_done = true; 

    }

    public void EndDialogue()
    {
        FindObjectOfType<Hiel>().isfinished = true;
        mur.SetActive(false);
        Invoke("PressBack", 0.2f);
    }

    private void PressBack()
    {
        GetComponent<Hiel>().check = false;
        GetComponent<Hiel>().isfinished = false;
        started = false; 
    }
}
