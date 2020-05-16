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

public class PopUp : MonoBehaviour
{

    public TextMeshProUGUI PopUpTxt;

    private string PopUpWarning; 
    
    void Start()
    {
        PopUpWarning = PlayerPrefs.GetString("popupwarn");
        PopUpTxt.text = PopUpWarning;
        Invoke("Disappear", 3);
    }
    
    private void Disappear()
    {
        SceneManager.UnloadSceneAsync("Pop Up"); 
    }
    
    
}
