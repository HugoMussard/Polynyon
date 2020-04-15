using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glypheenigma : MonoBehaviour
{
    public Interactable glyphe1;
    public Interactable glyphe2;
    public Interactable glyphe3;
    public Interactable glyphe4;
    public Interactable glyphe5;
    public Interactable glyphe6;
    public Interactable opener;

    // Update is called once per frame
    void Update()
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
}
