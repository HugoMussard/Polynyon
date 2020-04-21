using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public Transform button;
    public Interactable opener;
    public GameObject Rosedesventsobj;
    Animator anim;
    Animator animrdv;

    void Start()
    {
        anim = GetComponent<Animator>();
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
