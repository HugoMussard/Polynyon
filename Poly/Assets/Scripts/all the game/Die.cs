using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Die : MonoBehaviourPunCallbacks
{
    string scene;

    public Button tryagain; 
    

    // Start is called before the first frame update
    void Start()
    {
        tryagain.enabled = PhotonNetwork.IsMasterClient; 
        scene = PlayerPrefs.GetString("last_activescene");
    }
    

    public void TryAgain()
    {
        SceneManager.LoadScene(scene);
    }

    public void BackToMenu()
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
}
