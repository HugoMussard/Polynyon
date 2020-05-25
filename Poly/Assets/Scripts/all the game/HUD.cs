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

public class HUD : MonoBehaviour
{
    
    public TextMeshProUGUI txt;
    public GameObject ping;

    public TextMeshProUGUI txt2;

    public GameObject crosshair; 

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private int minutes = 15; 


    private void Start()
    {
        timer = 0.0f; 
        PlayerPrefs.SetInt("Fail", 0);
        PlayerPrefs.Save();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ping.SetActive(!ping.activeSelf);
        }
        txt.text = $"{PhotonNetwork.GetPing()} ms";

        if (PlayerPrefs.HasKey("CinematiqueON") && PlayerPrefs.GetInt("CinematiqueON") == 1)
            crosshair.SetActive(false);
        else crosshair.SetActive(true);
        

        if (SceneManager.GetSceneByName("IleBombe").isLoaded)
        {
            if (PlayerPrefs.GetInt("Malus_bool") == 1)
            {
                txt2.GetComponent<TextMeshProUGUI>().color = Color.red;
                PlayerPrefs.SetInt("Malus_bool", 0);
                PlayerPrefs.Save();
                minutes -= 5; 
                Invoke("BackToWh", 2);
            }

            if (minutes > 0)
            {
                if (timer >= 0.0f)
                {
                    timer -= Time.deltaTime;
                    if (timer >= 0.0f) txt2.text = $"{minutes}:{timer:F}";
                }

                else if (timer < 0.0f)
                {
                    minutes--;
                    timer = 60.0f;
                }
            }
            else
            {
                txt2.text = "0.00";
                timer = 0.0f;
                PlayerPrefs.SetInt("Fail", 1);
                PlayerPrefs.Save();
            }
        }
        
    }
    
    private void BackToWh()
    {
        txt2.GetComponent<TextMeshProUGUI>().color = Color.white; 
    }
}
