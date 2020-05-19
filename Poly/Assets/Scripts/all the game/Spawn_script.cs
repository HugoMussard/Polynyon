
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement; 
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Object = System.Object;

public class Spawn_script : MonoBehaviourPunCallbacks
{
   public string player_prefab;
   public string player_prefab2;
   public Transform spawn_point;
   public Transform spawn_point2;

   private GameObject clone1;
   private GameObject clone2;
   private camscript script1; 
   private camscript script2;

   public GameObject cam1;
   public GameObject cam2;
   public GameObject cam3;

   private bool cam1_bool; 
   private bool cam2_bool; 
   private bool cam3_bool; 
   
   
   private void Start()
   {
      script1 = null;
      script2 = null;
      Spawn();
      if(!SceneManager.GetSceneByName("HUD").isLoaded)
        SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
      if (!SceneManager.GetSceneByName("Blackscreen").isLoaded)
            SceneManager.LoadSceneAsync("Blackscreen", LoadSceneMode.Additive);
      if (!SceneManager.GetSceneByName("HelloUnity3D").isLoaded)
            SceneManager.LoadSceneAsync("HelloUnity3D", LoadSceneMode.Additive);
      
   }

   public void Spawn()
   {
      if (PhotonNetwork.IsMasterClient)
      {
         clone1 = PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
         script1 = clone1.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam")
               .GetComponent<camscript>();
      }
      else
      {
            clone2 = PhotonNetwork.Instantiate(player_prefab2, spawn_point2.position, spawn_point.rotation);
            script2 = clone2.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam2")
               .GetComponent<camscript>();
      }

   }
   
   public void Resume()
   {
      if (PhotonNetwork.IsMasterClient)
         script1.enabled = true;
      else script2.enabled = true;
      Cursor.visible = false; 
      Cursor.lockState = CursorLockMode.Locked;
      SceneManager.UnloadSceneAsync("BackFromGame");
      SceneManager.UnloadSceneAsync("TranspaESC"); 
      SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
   }

   
   
   private void Set_UnsetCam(bool state)
   {
      if (PhotonNetwork.IsMasterClient)
         clone1.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam").gameObject.SetActive(state);
      else clone2.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam2").gameObject.SetActive(state);
   }
   
   private IEnumerator Bakto_normalcam(GameObject camera, float delay)
   {
      yield return new WaitForSeconds(delay); 
      Set_UnsetCam(true);
      camera.SetActive(false);
   }
   
   private void Cam_cinematique(GameObject camera, float delay)
   {
      Set_UnsetCam(false);
      camera.SetActive(true);
      StartCoroutine(Bakto_normalcam(camera, delay)); 
   }
   
   
   

   void Update()
   {
      if (PlayerPrefs.HasKey("anim"))
      {
         if (PlayerPrefs.GetInt("anim") == 1 && !cam1_bool)
         {
            Cam_cinematique(cam1, 4);
            cam1_bool = true; 
         }

         if (PlayerPrefs.GetInt("anim") == 2 && !cam2_bool)
         {
            Cam_cinematique(cam2, 4);
            cam2_bool = true;
         }

         if (PlayerPrefs.GetInt("anim") == 3 && !cam3_bool)
         {
            Cam_cinematique(cam3, 6);
            cam3_bool = true;
         }
           
         
      }
      
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (!SceneManager.GetSceneByName("BackFromGame").isLoaded)
         {
            if (PhotonNetwork.IsMasterClient)
               script1.enabled = false;
            else script2.enabled = false;
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
            SceneManager.UnloadSceneAsync("HUD");
            SceneManager.LoadScene("TranspaESC", LoadSceneMode.Additive);
            SceneManager.LoadScene("BackFromGame", LoadSceneMode.Additive);
         }
         else Resume();
      }
      
   }
}


