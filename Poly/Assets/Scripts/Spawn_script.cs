
using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class Spawn_script : MonoBehaviour
{
   public string player_prefab;
   public string player_prefab2;
   public Transform spawn_point;
   public Transform spawn_point2;

   private GameObject clone1;
   private GameObject clone2;
   private camscript script1; 
   private camscript script2; 
   

   private void Start()
   {
      script1 = null;
      script2 = null;
      Spawn();
      SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
      SceneManager.LoadSceneAsync("Blackscreen", LoadSceneMode.Additive); 
   }

   public void Spawn()
   {

      if (PhotonNetwork.IsMasterClient)
      {
         clone1 = PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
         script1 = clone1.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam").GetComponent<camscript>(); 
      }
      else
      {
         clone2 = PhotonNetwork.Instantiate(player_prefab2, spawn_point2.position, spawn_point.rotation);
         script2 = clone2.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam2").GetComponent<camscript>(); 
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

   void Update()
   {
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


