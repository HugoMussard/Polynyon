using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Cross_Menu : MonoBehaviour
{
    public void OptionMenu()
    {
        SceneManager.UnloadSceneAsync("MENUOK");
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    public void BackToMenu()
    {
        SceneManager.UnloadSceneAsync("Options");
        SceneManager.LoadScene("MENUOK", LoadSceneMode.Additive);
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
