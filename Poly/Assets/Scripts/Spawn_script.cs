
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
 

   private void Start()
   {
     
      Spawn();
   }

   public void Spawn()
   {
      
      if (PhotonNetwork.IsMasterClient)
      {
         clone1 = PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
      }
      else
      {
         clone2 = PhotonNetwork.Instantiate(player_prefab2, spawn_point2.position, spawn_point.rotation);
      }
   }

   void Update()
   {
   
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (!SceneManager.GetSceneByName("BackFromGame").isLoaded)
         {
           

            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("BackFromGame", LoadSceneMode.Additive);
         }
         else
         {
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


