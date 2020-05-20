using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TP_Ile2 : MonoBehaviourPunCallbacks
{

    public GameObject tp1; 
    
  
    private void OnTriggerStay(Collider other1)
    {
        Debug.Log("zbi");
        other1.gameObject.transform.position = tp1.gameObject.transform.position;
    }
}
