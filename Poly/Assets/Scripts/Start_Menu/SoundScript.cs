using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
   
    private void Start()
    {
        slider.value = Convert.ToSingle(Math.Exp((1.0f / 19.539f) * PlayerPrefs.GetFloat("volume") - (99.962f / 19.539f)));
    }

    public void AdjustMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", Convert.ToInt32(19.539f * Math.Log(volume) + 99.962f));
        PlayerPrefs.Save();
    }




}
