using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class Biomes_HUB : MonoBehaviour
{
    public void _FstRoom()
    {
        SceneManager.LoadScene("premiere_salle"); 
    }

    public void _Bombe()
    {
        SceneManager.LoadScene("IleBombe"); 
    }

    public void Hub()
    {
        SceneManager.LoadScene("HUB");
    }

    public void Plaques()
    {
        SceneManager.LoadScene("Enigme_plaques"); 
    }

    public void Laby()
    {
        SceneManager.LoadScene("enigma1-1");
    }
    
}
