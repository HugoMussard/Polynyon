using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Cinematique_Pose_bombe : MonoBehaviour
{

    public Camera cam_pose_bombe;

    public Spawn_script spawn;

    public float delay = 10.6f;

    public GameObject cam_Sim1;
    public GameObject cam_Sim2;

    private void Start()
    {
        Invoke("Cam_Sim", 10.6f);
    }

    private void Cam_Sim()
    {
        cam_pose_bombe.enabled = false;
        Debug.Log("camsim");
        Set_UnsetCam(true);
        Invoke("Wait_spawn", 3.0f);
        
    }
    
    private void Set_UnsetCam(bool state)
    {
        if (PhotonNetwork.IsMasterClient)
            cam_Sim1.SetActive(state);
        else
            cam_Sim2.SetActive(state);
    }
    
    public void Wait_spawn()
    {
        Set_UnsetCam(false);
        spawn.enabled = true;
    }
    
}
