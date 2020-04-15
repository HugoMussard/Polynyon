using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour
{

    public TextMeshProUGUI Up;
    public TMP_InputField UpInput;
    
    public TextMeshProUGUI Down;
    public TMP_InputField DownInput;
    
    public TextMeshProUGUI Left;
    public TMP_InputField LeftInput;
    
    public TextMeshProUGUI Right;
    public TMP_InputField RightInput;
    
    public TextMeshProUGUI Vocal;
    public TMP_InputField VocalInput;


    private void Awake()
    {
        string hg = Directory.GetCurrentDirectory(); 
        if (!File.Exists($"{hg}/FirstRun"))
        {
            File.Create($"{hg}/FirstRun");
            PlayerPrefs.SetString("up", "Z");
            PlayerPrefs.SetString("down", "S");
            PlayerPrefs.SetString("left", "Q");
            PlayerPrefs.SetString("right", "D");
            PlayerPrefs.SetString("vocal", "V");
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        Up.text = PlayerPrefs.GetString("up");
        Down.text = PlayerPrefs.GetString("down");
        Left.text = PlayerPrefs.GetString("left");
        Right.text = PlayerPrefs.GetString("right");
        Vocal.text = PlayerPrefs.GetString("vocal"); 
    }

    public void Apply()
    {
        if (!String.IsNullOrEmpty(UpInput.text)) PlayerPrefs.SetString("up", UpInput.text);
        if (!String.IsNullOrEmpty(DownInput.text)) PlayerPrefs.SetString("down", DownInput.text);
        if (!String.IsNullOrEmpty(LeftInput.text)) PlayerPrefs.SetString("left", LeftInput.text);
        if (!String.IsNullOrEmpty(RightInput.text)) PlayerPrefs.SetString("right", RightInput.text);
        if (!String.IsNullOrEmpty(VocalInput.text)) PlayerPrefs.SetString("vocal", VocalInput.text);
        PlayerPrefs.Save();
    }

    public void ReturnToOption()
    {
        SceneManager.UnloadSceneAsync("KeyBind");
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive); 
    }

    
}
