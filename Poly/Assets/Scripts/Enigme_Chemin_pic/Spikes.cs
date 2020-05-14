using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using UnityEngine.SceneManagement;


public class Spikes : MonoBehaviourPunCallbacks
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (moves.Istrapped)
        {
            anim.SetBool("Spike", true);
            Invoke("Die", 1);
        }
    }

    private void Die()
    {
        PhotonNetwork.LoadLevel("Enigme_plaques");
    }

}

