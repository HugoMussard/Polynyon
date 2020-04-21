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

public class Load_Newgame : MonoBehaviourPunCallbacks
{

    private string save;
    
    
    
    void Start()
    {
        save = PlayerPrefs.GetString("save");
        
    }

    public void LoadSave()
    {
        if (save == "") Debug.Log("U dont have a save yet"); 
        else PhotonNetwork.LoadLevel($"{save}");
    }

    public void NewGame()
    {
        if (save != "") Debug.Log("Etes vous sur de vouloir écraser votre sauvegarde ?");
        PhotonNetwork.LoadLevel("IleBombe");
    }
    
}
