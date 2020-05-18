using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class UnlockIndices_Ile2 : MonoBehaviourPunCallbacks
{
    public int nb;

    public GameObject porte;
    public GameObject trappe;
    public GameObject planches;
    
    private Animator anim1;
    private Animator anim2;
    private Animator anim3;


    public GameObject coll_trappe;
    public GameObject coll_tente_verte; 

    public ParticleSystem explosion_planche; 

    private void Start()
    {
        anim1 = porte.GetComponent<Animator>();
        anim2 = trappe.GetComponent<Animator>();
        anim3 = planches.GetComponent<Animator>();
        coll_trappe.SetActive(false);
        coll_tente_verte.SetActive(false);
        explosion_planche.Stop(true);
    }

    [PunRPC]
    public void Set_act_coll()
    {
        coll_trappe.SetActive(true);
    }
    
    
    [PunRPC]
    public void Set_act_coll2()
    {
        coll_tente_verte.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
     
            if (nb == 1)
            {
                anim1.SetBool("Porte_bool", true);
                nb = 0;
            }

            if (nb == 2)
            {
                anim2.SetBool("Trappe_bool", true);
                photonView.RPC("Set_act_coll", RpcTarget.All);
                nb = 0; 
            }

            if (nb == 3)
            {
                if (!explosion_planche.isPlaying) explosion_planche.Play(true);
                anim3.SetBool("Explosion_bool", true);
                photonView.RPC("Set_act_coll2", RpcTarget.All);
                nb = 0;
            }
        
        
    }
}
