using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigma1 : MonoBehaviour
{
    Interactable glyphe1;
    Interactable glyphe2;
    Interactable glyphe3;
    Interactable glyphe4;
    Interactable glyphe5;
    Interactable glyphe6;
    Interactable opener;

    // Update is called once per frame
    void Update()
    {
        if (glyphe1.state || glyphe2.state || glyphe4.state || glyphe6.state)
        { }
        else
        {
            if (glyphe3.state && glyphe5.state)
            {
                opener.state = true;
            }
        }
    }
}
