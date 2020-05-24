using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gohub : MonoBehaviourPunCallbacks
{
    public string load;
    private void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene(load);
    }
    
}
