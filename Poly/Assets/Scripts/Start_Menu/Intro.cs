using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioSource hg; 
  
    private void Awake()
    {
        hg.volume = PlayerPrefs.GetFloat("volume");
    }

    void Start()
    {
        SceneManager.LoadScene("Blackscreen", LoadSceneMode.Additive); 
        SceneManager.LoadScene("MENUOK", LoadSceneMode.Additive);
    }

    private void Update()
    {
        hg.volume = PlayerPrefs.GetFloat("volume");
    }
}
