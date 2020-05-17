using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class grilles : MonoBehaviourPunCallbacks
{
    Transform transf;
    private bool button;
    private bool button2;
    // Start is called before the first frame update
    void Start()
    {
        transf = GetComponent<Transform>();
    }

    [PunRPC]
    public void SetBool(int compteur) 
    {
        if (compteur == 1)
        {
            if (!button) button = true;
            else button2 = true; 
        }
    }

    [PunRPC]
    public void UnsetBool(int compteur2)
    {
        if (compteur2 == 1)
        {
            if (button) button = false;
            else button2 = false; 
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (button && button2)
        {
            transf.position = new Vector3(transf.position.x, 8f, transf.position.z);
        }

    }
}
