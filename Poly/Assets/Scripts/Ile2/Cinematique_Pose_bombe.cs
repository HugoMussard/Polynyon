using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique_Pose_bombe : MonoBehaviour
{

    public Camera cam_pose_bombe;

    public Spawn_script spawn;

    public float delay = 11.0f; 

    private void Start()
    {
        Invoke("Wait_spawn", delay);
    }

    public void Wait_spawn()
    {
        spawn.enabled = true;
        cam_pose_bombe.enabled = false; 
    }
    
}
