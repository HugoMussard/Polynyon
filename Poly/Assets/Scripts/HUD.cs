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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ping.SetActive(!ping.activeSelf);
        }
        txt.text = $"{PhotonNetwork.GetPing()} ms";

    }
}
