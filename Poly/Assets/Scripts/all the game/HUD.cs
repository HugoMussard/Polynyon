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

public class HUD : MonoBehaviour
{
    
    public TextMeshProUGUI txt;
    public GameObject ping;

    public TextMeshProUGUI txt2;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private int minutes = 15; 


    private void Start()
    {
        timer = 8.0f; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ping.SetActive(!ping.activeSelf);
        }
        txt.text = $"{PhotonNetwork.GetPing()} ms";


        if (SceneManager.GetSceneByName("IleBombe").isLoaded)
        {
            if (timer >= 0.0f && canCount)
            {
                timer -= Time.deltaTime;
                if (timer >= 0.0f) txt2.text = $"{minutes}:{timer:F}";
            }

            else if (timer <= 0.0f && !doOnce)
            {
                if (minutes > 0)
                {
                    minutes--;
                    timer = 60.0f;
                }
                else
                {
                    canCount = false;
                    doOnce = true;
                    txt2.text = "0.00";
                    timer = 0.0f;
                }

            }
        }
    }
}
