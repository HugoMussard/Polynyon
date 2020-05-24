using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Die : MonoBehaviourPunCallbacks
{
    string scene;
    

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Enigme_plaques");
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
