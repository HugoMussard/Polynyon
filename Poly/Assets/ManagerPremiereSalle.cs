using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ManagerPremiereSalle : MonoBehaviour
{

    public GameObject script_spawn;
    public GameObject perso1clone;
    public GameObject perso2clone;

    public GameObject cam_cinematique1;
    public GameObject cam_cinematique2;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            cam_cinematique1.SetActive(true);
        }
        else
        {
            cam_cinematique2.SetActive(true);
        }
        Invoke("Spawnplayer", 5.2f);
        Invoke("Destroy",5.1f);
    }

    void Destroy()
    {
        Destroy(perso1clone);
        Destroy(perso2clone);
    }
    void Spawnplayer()
    {
        script_spawn.SetActive(true);
    }
    // Update is called once per frame
    
    void Update()
    {
            
    }
}