using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class glypheenigma : MonoBehaviour
{
    public Interactable glyphe1;
    public Interactable glyphe2;
    public Interactable glyphe3;
    public Interactable glyphe4;
    public Interactable glyphe5;
    public Interactable glyphe6;
    public Interactable opener;
    public int enigm = 0;


    void Start()
    {
        System.Random random = new System.Random();
        enigm = random.Next(3);

    }
    // Update is called once per frame
    void Update()
    {
        if (enigm == 0)
        {
            if (glyphe1.state || glyphe2.state || glyphe4.state || glyphe6.state)
            {
                opener.state = false;
            }
            else
            {
                if (glyphe3.state && glyphe5.state)
                {
                    opener.state = true;
                }
                else
                {
                    opener.state = false;
                }
            }
        }
        if (enigm == 1)
        {
            if (glyphe1.state || glyphe3.state || glyphe4.state || glyphe5.state)
            {
                opener.state = false;
            }
            else
            {
                if (glyphe6.state && glyphe2.state)
                {
                    opener.state = true;
                }
                else
                {
                    opener.state = false;
                }
            }
        }
        if (enigm == 2)
        {
            if (glyphe1.state || glyphe3.state || glyphe4.state || glyphe6.state)
            {
                opener.state = false;
            }
            else
            {
                if (glyphe2.state && glyphe5.state)
                {
                    opener.state = true;
                }
                else
                {
                    opener.state = false;
                }
            }
        }
    }
}
