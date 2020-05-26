using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager2 : MonoBehaviour
{

    public GameObject script_spawn;
    public Spawn_script spawn;

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
        Invoke("Spawnplayer", 1.6f);
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
