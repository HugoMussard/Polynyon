using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Cross_Menu : MonoBehaviour
{
    private string Scenesave;
    
    public void SaveClick()
    {
        if (PhotonNetwork.IsMasterClient) 
            PlayerPrefs.SetString("save", SceneManager.GetActiveScene().name);
        else
        {
            PlayerPrefs.SetString("popupwarn", "Only MasterClient can save the game !");
            SceneManager.LoadSceneAsync("Pop Up", LoadSceneMode.Additive);
        }
        
    }

    public void OptionMenu()
    {
        if (SceneManager.GetSceneByName("Polynon Scene").isLoaded) SceneManager.UnloadSceneAsync("MENUOK");
        else SceneManager.UnloadSceneAsync("BackFromGame");
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    public void BackToMenu()
    {
        if (SceneManager.GetSceneByName("Polynon Scene").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Options");
            SceneManager.LoadScene("MENUOK", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync("Options");
            SceneManager.LoadScene("BackFromGame", LoadSceneMode.Additive);
        }
        
    }


    public void BackFromGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.Players.Count <= 1)
            {
                PhotonNetwork.Disconnect();
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                SceneManager.LoadScene("Polynon Scene");
            }
            else Debug.Log("All players must be disconnected first");
        }
        else
        {
            PhotonNetwork.Disconnect();
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene("Polynon Scene");
        }
    }
    


    public void PlayButt()
    {
        SceneManager.UnloadSceneAsync("MENUOK");
        SceneManager.LoadScene("lobby", LoadSceneMode.Additive); 
    }


    public void ExitGame()
    {
        Application.Quit(); 
    }
}
