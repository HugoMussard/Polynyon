using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class Morpiege : MonoBehaviour
{
    public Spawn_script spawn;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("waitforSpawn", 2.1f);
    }

    void waitforSpawn()
    {
        anim = spawn.clone1.transform.Find("Character").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Die();
    }
    private void Set_UnsetMov(bool state)
    {
        if (PhotonNetwork.IsMasterClient)
            spawn.clone1.GetComponent<moves>().enabled = state; 
        else 
            spawn.clone2.GetComponent<moves>().enabled = state; 
    }
    void Die()
    {
        anim.SetBool("Die", true);
        Set_UnsetMov(false);
        Invoke("jsp", 2);
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

    void jsp()
    {
        SceneManager.LoadScene("Die");
    }
}
