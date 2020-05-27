using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerBombe : MonoBehaviour
{
    
    
    
    public AudioSource bomb_planted;

    public float bomb_planted_delay;

    public AudioSource tense_music; 
    
    
    void Start()
    {
        Invoke("Bomb_planted", bomb_planted_delay);
        Invoke("TenseMusic", 14.0f);
        
    }

    private void Bomb_planted()
    {
        bomb_planted.Play();
    }

    private void TenseMusic()
    {
        tense_music.Play();
    }
    
}
