using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager2 : MonoBehaviour
{

    public GameObject script_spawn;

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
        Invoke("start_spawn_script",2);
    }

    // Update is called once per frame
    public void start_spawn_script()
    {
        cam_cinematique1.SetActive(false);
        cam_cinematique2.SetActive(false);
        
        script_spawn.SetActive(true);
    }
    void Update()
    {
            
    }
}
