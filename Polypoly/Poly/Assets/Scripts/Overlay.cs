using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlay : MonoBehaviour 
{
   
    public Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brightness"); 
    }


    public void Ptn(float tamerelatchoin)
    {
       PlayerPrefs.SetFloat("brightness", tamerelatchoin);
       PlayerPrefs.Save();
       
    }
}
