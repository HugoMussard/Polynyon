using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.IO;
using Photon.Pun;


public class Intro : MonoBehaviourPunCallbacks
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
        PhotonNetwork.Disconnect();
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
