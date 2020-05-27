using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.IO;


public class Intro : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioSource hg; 
  
    private void Awake()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume")); 

        if (!File.Exists($"{Application.dataPath}/firstrun"))
        {
            File.Create($"{Application.dataPath}/firstrun");
            PlayerPrefs.SetString("up", "Z");
            PlayerPrefs.SetString("down", "S");
            PlayerPrefs.SetString("left", "Q");
            PlayerPrefs.SetString("right", "D");
            PlayerPrefs.SetString("vocal", "V");
            PlayerPrefs.SetString("run", "LeftShift");
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        SceneManager.LoadScene("Blackscreen", LoadSceneMode.Additive); 
        SceneManager.LoadScene("MENUOK", LoadSceneMode.Additive);
    }

    private void Update()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
    }
}
