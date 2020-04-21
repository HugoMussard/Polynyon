using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gohub : MonoBehaviourPunCallbacks
{
    //public LayerMask hub;
    //public float groundis = 0.5f;
    //public Transform Hubcheck;
    
    public PhotonView player1;
    public PhotonView player2; 

  

    private void OnTriggerEnter(Collider collider)
    {
        SceneManager.UnloadSceneAsync("HUD");
        SceneManager.UnloadSceneAsync("Blackscreen");
        SceneManager.UnloadSceneAsync("HelloUnity3D");
        SceneManager.LoadSceneAsync("HUB");
        //PhotonNetwork.LoadLevel("HUB");
    }
    
}
