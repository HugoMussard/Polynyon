using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique_Pose_bombe : MonoBehaviour
{

    public Camera cam_pose_bombe;

    public Spawn_script spawn;

    private void Start()
    {
        Invoke("Wait_spawn", 11.0f);
    }

    public void Wait_spawn()
    {
        spawn.enabled = true;
        cam_pose_bombe.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
