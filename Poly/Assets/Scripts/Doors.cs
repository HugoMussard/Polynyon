
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
    float speed = -0.2f;
 

    /*void Update()
    {
        photonView.RPC("Descente", RpcTarget.All);
    }

    */
    
    

    private void Update()
    {
        //if (!photonView.IsMine) return; 
        //if (this == null) return; 
        if (opener.state && transform.position.y > -3.5f)
        {
            if (photonView.Owner == PhotonNetwork.LocalPlayer)
                transform.Translate(Vector3.down * (Time.deltaTime * 1.0f));
            else
            {
                photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
                transform.Translate(Vector3.down * (Time.deltaTime * 1.0f));
            }

        }
    } 
   
}
