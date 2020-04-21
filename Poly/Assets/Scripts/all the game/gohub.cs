using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gohub : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider collider)
    {
        PhotonNetwork.LoadLevel("HUB");
    }
    
}
