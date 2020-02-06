using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Cross_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

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

    public void ExitGame()
    {
        Application.Quit(); 
    }
}
