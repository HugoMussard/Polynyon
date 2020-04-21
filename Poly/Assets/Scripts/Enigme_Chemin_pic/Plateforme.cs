using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Plateforme : MonoBehaviour
{
    public Transform instructions;

    public Transform murquibouge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (murquibouge.position.x > 30f)
        {
            Die();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        murquibouge.Translate(Vector3.right * (Time.deltaTime * 0.5f));
        instructions.transform.position = new Vector3(32,2,0);
    }

    private void OnTriggerExit(Collider other)
    {
        instructions.transform.position = new Vector3(33,2,0);
    }

    private void Die()
    {
        PhotonNetwork.LoadLevel("Enigme_plaques");
    }
}
