using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematique_unlock_indice : MonoBehaviourPunCallbacks
{
    public Spawn_script SpawnScript; 
    
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private bool cam1_bool; 
    private bool cam2_bool; 
    private bool cam3_bool;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CinematiqueON", 0);
        PlayerPrefs.Save();
        
    }

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
        if (PlayerPrefs.HasKey("anim"))
        {
            if (PlayerPrefs.GetInt("anim") == 1 && !cam1_bool)
            {
                Cam_cinematique(cam1, 4);
                cam1_bool = true; 
                Invoke("Crosshair_Back", 4);
            }

            if (PlayerPrefs.GetInt("anim") == 2 && !cam2_bool)
            {
                Cam_cinematique(cam2, 4);
                cam2_bool = true;
                Invoke("Crosshair_Back", 4);
            }

            if (PlayerPrefs.GetInt("anim") == 3 && !cam3_bool)
            {
                Cam_cinematique(cam3, 6);
                cam3_bool = true;
                Invoke("Crosshair_Back", 6);
            }
        }
        
    }

    private void Crosshair_Back()
    {
        PlayerPrefs.SetInt("CinematiqueON", 0);
        PlayerPrefs.Save();
    }
    
}
