
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 


public class Doors : MonoBehaviourPunCallbacks
{
    public Transform door;
    public Interactable opener;
    float speed = - 0.2f;
    private void Start()
    {
        if (!photonView.IsMine) return;
    }

    void Update()
    {
        photonView.RPC("Descente", RpcTarget.All);
    }
    
    [PunRPC]
    void Descente()
    {
        //if (!photonView.IsMine) return;
        if (opener.state && transform.position.y < -3.5f)
        {
            //collider.enabled = false;
            transform.Translate(Vector3.up * (Time.deltaTime * 1.0f));
            
        }
    } 
   
}
