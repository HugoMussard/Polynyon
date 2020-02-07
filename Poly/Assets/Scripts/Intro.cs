using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public AudioMixer audioMixer;
    

    void Start()
    {
        SceneManager.LoadScene("Blackscreen", LoadSceneMode.Additive); 
        SceneManager.LoadScene("MENUOK", LoadSceneMode.Additive);
        float music = PlayerPrefs.GetFloat("volume", 10f); 

    }

  



}
