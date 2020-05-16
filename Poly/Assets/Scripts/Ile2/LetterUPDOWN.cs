using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUPDOWN : MonoBehaviour
{

    public GameObject letter;

    public Interactable interactable;

    public int Haut_bas; 


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
            int i = 0;
            bool check = false;
            GameObject actualLetter = null; 
            while(i < letter.transform.childCount && !check)
            {
                if (letter.transform.GetChild(i).gameObject.activeSelf)
                {
                    actualLetter = letter.transform.GetChild(i).gameObject;
                    check = true; 
                }
                i++;
            }

            
            
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
                letter.transform.Find(_tabLettres[newPos]).gameObject.SetActive(true);
            }
            interactable.state = false; 
        }
    }
}
