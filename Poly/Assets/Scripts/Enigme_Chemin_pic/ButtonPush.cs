using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public Interactable opener;
    public GameObject Rosedesventsobj;
    public GameObject Boutonrouge;
    Animator anim;
    Animator animrdv;

    void Start()
    {
        anim = Boutonrouge.GetComponent<Animator>();
        animrdv = Rosedesventsobj.GetComponent<Animator>();
    }

    

    void Update()
    {
        if (opener.state)
        {
            
            anim.SetBool("Button_state", true);
            animrdv.SetBool("Sort", true);
            

        }
        else
        {
            anim.SetBool("Button_state", false);
        }
    }
}
