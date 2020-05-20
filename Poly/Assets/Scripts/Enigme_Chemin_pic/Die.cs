using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Die : MonoBehaviourPunCallbacks
{
    
   
    // Start is called before the first frame update
    void Start()
    {
        
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
}
