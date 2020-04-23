using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Plateforme : MonoBehaviour
{
    public Transform instructions;
    public Transform plaquedroite;
    Animator anim;
    public static bool plateformetrigger;

    //public Transform murquibouge;
    // Start is called before the first frame update
    void Start()
    {
        anim = instructions.GetComponent<Animator>();
        plateformetrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        anim.SetBool("Trigger", true);
        plateformetrigger = true;

    }

    void OnTriggerExit(Collider other)
    {
        anim.SetBool("Trigger", false);
        plateformetrigger = false;
    }

    private void Die()
    {
        PhotonNetwork.LoadLevel("Enigme_plaques");
    }
}
