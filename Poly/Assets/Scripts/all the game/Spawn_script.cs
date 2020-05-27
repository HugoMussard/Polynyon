
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
   
   public GameObject clone1;
   public GameObject clone2;
   
   public camscript cam1; 
   public camscript cam2;

   public GameObject camobject1;
   public GameObject camobject2;

   
   private void Start()
   {
      Spawn();
      if(!SceneManager.GetSceneByName("HUD").isLoaded)
        SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
      if (!SceneManager.GetSceneByName("Blackscreen").isLoaded)
            SceneManager.LoadSceneAsync("Blackscreen", LoadSceneMode.Additive);
      if (!SceneManager.GetSceneByName("HelloUnity3D").isLoaded)
            SceneManager.LoadSceneAsync("HelloUnity3D", LoadSceneMode.Additive);
      PlayerPrefs.SetString("last_activescene", SceneManager.GetActiveScene().name);
      PlayerPrefs.Save();
      
   }

   public void Spawn()
   {
      if (PhotonNetwork.IsMasterClient)
      {
         clone1 = PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
         cam1 = clone1.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam")
            .GetComponent<camscript>();
      }
      else
      { 
         clone2 = PhotonNetwork.Instantiate(player_prefab2, spawn_point2.position, spawn_point2.rotation);
         cam2 = clone2.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam2")
            .GetComponent<camscript>();
      }

   }
   
   
   
   public void Resume(bool state)
   {
      if (PhotonNetwork.IsMasterClient)
         cam1.enabled = state;
      else cam2.enabled = state;
      Cursor.visible = !state;
      if (!state)
      {
         Cursor.lockState = CursorLockMode.None;
         PlayerPrefs.SetInt("CinematiqueON", 1);
         PlayerPrefs.Save();
         SceneManager.LoadScene("TranspaESC", LoadSceneMode.Additive);
         SceneManager.LoadScene("BackFromGame", LoadSceneMode.Additive);
      }
      else
      {
         Cursor.lockState = CursorLockMode.Locked;
         SceneManager.UnloadSceneAsync("BackFromGame");
         SceneManager.UnloadSceneAsync("TranspaESC"); 
         PlayerPrefs.SetInt("CinematiqueON", 0);
         PlayerPrefs.Save();
      }
   }
   

   void Update()
   {
      
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (!SceneManager.GetSceneByName("BackFromGame").isLoaded && !SceneManager.GetSceneByName("Options").isLoaded && !SceneManager.GetSceneByName("KeyBind").isLoaded)
            Resume(false);
         else if (!SceneManager.GetSceneByName("Options").isLoaded && !SceneManager.GetSceneByName("KeyBind").isLoaded)
            Resume(true);
      }
   }
   
   
}


