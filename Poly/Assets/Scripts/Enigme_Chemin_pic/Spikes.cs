using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using UnityEngine.SceneManagement;


public class Spikes : MonoBehaviourPunCallbacks
{
    public Transform spike;

    private void Start()
    {
    }

    private void Update()
    {
        if (moves.Istrapped && transform.position.y < -0.44)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * 15f));
            Invoke("Die", 1);
        }
    }

    private void Die()
    {
        PhotonNetwork.LoadLevel("Enigme_plaques");
    }

}

