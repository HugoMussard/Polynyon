
using Photon.Pun;

using UnityEngine;

public class Spawn_script : MonoBehaviour
{
   public string player_prefab;
   public Transform spawn_point;


   private void Start()
   {
      Spawn(); 
   }

   public void Spawn()
   {
      PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation); 
   }
}
