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
        PlayerPrefs.DeleteKey("1-1");
        PlayerPrefs.DeleteKey("1-2");
        PlayerPrefs.DeleteKey("1-3");
        PlayerPrefs.DeleteKey("1-4");
        PlayerPrefs.Save();
        SceneManager.LoadScene("premiere_salle");

    }

    public void Biomes()
    {
        SceneManager.UnloadSceneAsync("Load_NewGame"); 
        SceneManager.LoadScene("BIOMES SOLVED", LoadSceneMode.Additive); 
    }

    public void Back()
    {
        PhotonNetwork.Disconnect();
        SceneManager.UnloadSceneAsync("Load_NewGame");
        SceneManager.LoadScene("lobby", LoadSceneMode.Additive); 
    }
    
}
