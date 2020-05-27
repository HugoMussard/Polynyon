using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class New_Keybind : MonoBehaviour
{
    public TMP_InputField input;
    
    
    void Update()
    {
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey))
            {
                input.text = Convert.ToString(vKey); 
            }
        }
    }
}
