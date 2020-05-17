using System;
using Photon.Pun;
using UnityEngine;
//on essaye de voir ce que ca donne
public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public bool state;

    public GameObject object_bool;

    private int compteur;
    private int compteur2; 
    
    
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        if (state && object_bool != null)
        {
            compteur += 1; 
            object_bool.GetComponent<PhotonView>().RPC("SetBool", RpcTarget.All, compteur);
            compteur2 = 0; 
        }
        else if (object_bool != null)
        {
            compteur2 += 1; 
            object_bool.GetComponent<PhotonView>().RPC("UnsetBool", RpcTarget.All, compteur2);
            compteur = 0; 
        }
    }
}
