using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class Morpiege : MonoBehaviour
{
    public Spawn_script spawn;

    public static bool die;
    // Start is called before the first frame update
    void Start()
    {
        die = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Die();
    }
    
    void Die()
    {
        die = true;
        SceneManager.LoadScene("Die", LoadSceneMode.Additive);
        if (PhotonNetwork.IsMasterClient)
            spawn.cam1.enabled = false;
        else
        {
            spawn.cam2.enabled = false;
        }

        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (SceneManager.GetSceneByName("HUD").isLoaded)
        {
            SceneManager.UnloadSceneAsync("HUD");
        }
    }
}
