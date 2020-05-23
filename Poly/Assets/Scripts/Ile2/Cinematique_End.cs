using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematique_End : MonoBehaviourPunCallbacks
{
    public MainCable MC;
    public Mdp_enigme MDP;
    public Spawn_script SpawnScript;

    public GameObject CameraEnd;
    private bool check; 
    
    public bool FinishFils;
    
    public bool Finishmdp;
    
    public GameObject doors; 
    
    private Animator anim1;
    private Animator animDoors;

    public Camera Cam3;

    public GameObject militaire;

    public GameObject tpmilit; 


    private void Start()
    {
        //anim1 = milit.GetComponent<Animator>();
        animDoors = doors.GetComponent<Animator>(); 
    }


    private void Set_UnsetCam(bool state)
    {
        Cam3.enabled = state; 
    }

    private void Set_UnsetMov(bool state)
    {
        if (PhotonNetwork.IsMasterClient)
            SpawnScript.clone1.GetComponent<moves>().enabled = state; 
        else 
            SpawnScript.clone2.GetComponent<moves>().enabled = state; 
    }
   
    private IEnumerator Bakto_normal(GameObject camera, float delay)
    {
        yield return new WaitForSeconds(delay); 
        Set_UnsetCam(true);
        Set_UnsetMov(true);
        camera.SetActive(false);
    }
    
    private void Cam_cinematique(GameObject camera, float delay)
    {
        Set_UnsetCam(false);
        Set_UnsetMov(false);
        PlayerPrefs.SetInt("CinematiqueON", 1);
        PlayerPrefs.Save();
        camera.SetActive(true);
        StartCoroutine(Bakto_normal(camera, delay));
    }


    // Update is called once per frame
    void Update()
    {
        if (FinishFils && Finishmdp && !check)
        {
            militaire.transform.position = tpmilit.transform.position; 
            Cam_cinematique(CameraEnd, 4.5f);
            //anim1.SetBool();
            animDoors.SetBool("Doors_bool", true);
            check = true; 
            Invoke("Crosshair_Back", 4.5f);
        }
        
    }
    
    
    private void Crosshair_Back()
    {
        PlayerPrefs.SetInt("CinematiqueON", 0);
        PlayerPrefs.Save();
    }
}
