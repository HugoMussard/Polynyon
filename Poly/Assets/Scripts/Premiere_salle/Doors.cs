
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 


public class Doors : MonoBehaviourPunCallbacks
{
    public Interactable opener;


    private void Update()
    {
        if (opener.state && transform.position.y > -3.3f)
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
