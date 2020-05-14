using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDown : MonoBehaviour
{

    public GameObject letter;

    public Interactable interactable; 
    
    
    
 

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
                actualLetter.SetActive(false);
                letter.transform.Find(Convert.ToString(Convert.ToChar(Convert.ToInt32(Convert.ToChar(actualLetter.name)) + 1))).gameObject.SetActive(true); 
            }
            interactable.state = false; 
        }
    }
}
