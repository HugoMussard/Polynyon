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
    
    public TextMeshProUGUI Run;
    public TMP_InputField RunInput;
    

    void Start()
    {
        Up.text = PlayerPrefs.GetString("up");
        Down.text = PlayerPrefs.GetString("down");
        Left.text = PlayerPrefs.GetString("left");
        Right.text = PlayerPrefs.GetString("right");
        Vocal.text = PlayerPrefs.GetString("vocal");
        Run.text = PlayerPrefs.GetString("run");
        UpInput.DeactivateInputField();
        DownInput.DeactivateInputField();
    }

    public void Apply()
    {
        if (!String.IsNullOrEmpty(UpInput.text)) PlayerPrefs.SetString("up", UpInput.text);
        if (!String.IsNullOrEmpty(DownInput.text)) PlayerPrefs.SetString("down", DownInput.text);
        if (!String.IsNullOrEmpty(LeftInput.text)) PlayerPrefs.SetString("left", LeftInput.text);
        if (!String.IsNullOrEmpty(RightInput.text)) PlayerPrefs.SetString("right", RightInput.text);
        if (!String.IsNullOrEmpty(VocalInput.text)) PlayerPrefs.SetString("vocal", VocalInput.text);
        if (!String.IsNullOrEmpty(RunInput.text)) PlayerPrefs.SetString("run", Run.text);
        PlayerPrefs.Save();

    }

    public void ReturnToOption()
    {
        SceneManager.UnloadSceneAsync("KeyBind");
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive); 
    }

    public void Set_script(New_Keybind script)
    {
        script.enabled = true;
        Debug.Log("first");
    }

    public void Unset_script(New_Keybind script)
    {
        script.enabled = false; 
    }

    
}
