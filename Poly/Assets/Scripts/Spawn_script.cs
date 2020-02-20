
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
   public Transform spawn_point;
   public Transform spawn_point2;
  


   private void Start()
   {
      Spawn(); 
   }

   public void Spawn()
   {
      
      if (PhotonNetwork.IsMasterClient)
      {
         PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
      }
      else
      {
         PhotonNetwork.Instantiate(player_prefab, spawn_point2.position, spawn_point.rotation);
      }
   }
}
