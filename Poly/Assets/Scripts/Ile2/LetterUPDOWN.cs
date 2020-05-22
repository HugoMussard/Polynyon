using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUPDOWN : MonoBehaviour
{

    public GameObject letter;

    public Interactable interactable;

    public int Haut_bas; 
    
    public GameObject actualLetter;

    public LetterUPDOWN otherOne; 


    private string[] _tabLettres =
    {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
        "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
    };


 

    // Update is called once per frame
    void Update()
    {
        if (interactable.state)
        {
            if (actualLetter != null)
            {
                int pos = Array.IndexOf(_tabLettres, actualLetter.name);
                int newPos;
                if (Haut_bas == 0) newPos = (pos + 1) % 26;
                else
                {
                    newPos = pos - 1;
                    newPos = newPos < 0 ? 26 + newPos : newPos; 
                }
                actualLetter.SetActive(false);
                actualLetter = letter.transform.Find(_tabLettres[newPos]).gameObject;
                otherOne.actualLetter = letter.transform.Find(_tabLettres[newPos]).gameObject;
                actualLetter.SetActive(true);    
            }
            interactable.state = false; 
        }
    }
}
