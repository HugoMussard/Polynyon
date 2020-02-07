using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blackscreen : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("brightness"))
        {
            PlayerPrefs.SetFloat("brightness", 1.0f);
            PlayerPrefs.Save();
            
        }
        
    }

    void Update()
    {
        var tempColor = image.color;
        tempColor.a = 1.0f - PlayerPrefs.GetFloat("brightness"); 
        PlayerPrefs.Save();
        image.color = tempColor;
        
        
    }
    
}
