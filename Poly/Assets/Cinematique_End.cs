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
    
    
    private void Set_UnsetCam(bool state)
    {
        if (PhotonNetwork.IsMasterClient)
            SpawnScript.clone1.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam").gameObject.SetActive(state);
        else 
            SpawnScript.clone2.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam2").gameObject.SetActive(state);
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
            Cam_cinematique(CameraEnd, 15);
            check = true; 
            Invoke("Crosshair_Back", 15);
        }
        
    }
    
    
    private void Crosshair_Back()
    {
        PlayerPrefs.SetInt("CinematiqueON", 0);
        PlayerPrefs.Save();
    }
}
