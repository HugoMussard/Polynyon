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
        slider.value = PlayerPrefs.GetFloat("volume"); 
    }

    public void AdjustMusicVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("volume", volume);
        //Save changes
        PlayerPrefs.Save();
    }




}
