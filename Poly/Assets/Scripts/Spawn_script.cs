
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
   public TextMeshProUGUI txt;
   public GameObject ping;
   private GameObject clone1;
   private GameObject clone2;
   private camscript script1; 
   private camscript script2; 
   

   private void Start()
   {
      script1 = null;
      script2 = null;
      Spawn();
     
   }

   public void Spawn()
   {

      if (PhotonNetwork.IsMasterClient)
      {
         clone1 = PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
         script1 = clone1.transform.Find("GameObject").transform.Find("player_cam").GetComponent<camscript>();
      }
      else
      {
         clone2 = PhotonNetwork.Instantiate(player_prefab2, spawn_point2.position, spawn_point.rotation);
         script2 = clone2.transform.Find("GameObject").transform.Find("player_cam2").GetComponent<camscript>(); 
      }
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
            SceneManager.LoadScene("BackFromGame", LoadSceneMode.Additive);
         }
         else
         {
            if (PhotonNetwork.IsMasterClient)
               script1.enabled = true;
            else script2.enabled = true;
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.UnloadSceneAsync("BackFromGame");
         }
      }
      
      
      if (Input.GetKeyDown(KeyCode.P))
      {
         ping.SetActive(!ping.activeSelf);
      }
      txt.text = $"{PhotonNetwork.GetPing()} ms";
      
   }
}


