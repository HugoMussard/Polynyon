using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail_Bombe : MonoBehaviourPunCallbacks
{

    private bool check;

    public ParticleSystem explosion_bombe; 
    
    Animator anim;
    
    public Spawn_script spawn;
   
    
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        explosion_bombe.Stop(true);
        Invoke("waitforSpawn", 14f);
        //PlayerPrefs.SetInt("Fail", 0);
        //PlayerPrefs.Save();
    }
    
    void waitforSpawn()
    {
        if (PhotonNetwork.IsMasterClient)
            anim = spawn.clone1.transform.Find("Character").GetComponent<Animator>();
        else anim = spawn.clone2.transform.Find("Character").GetComponent<Animator>(); 
    }
    
    private void Set_UnsetMov(bool state)
    {
        if (PhotonNetwork.IsMasterClient)
            spawn.clone1.GetComponent<moves>().enabled = state; 
        else 
            spawn.clone2.GetComponent<moves>().enabled = state; 
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!check && PlayerPrefs.GetInt("Fail") == 1)
        {
            if (!explosion_bombe.isPlaying) 
                explosion_bombe.Play(true);
            check = true; 
            
            Die();
            
        }

    }
    
    
    void Die()
    {
        anim.SetBool("Die", true);
        Set_UnsetMov(false);
        SceneManager.LoadScene("Die additive", LoadSceneMode.Additive);
        Invoke("LoadDieScene", 3);
        if (PhotonNetwork.IsMasterClient)
        {
            spawn.cam1.enabled = false;
        }
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

    void LoadDieScene()
    {
        SceneManager.LoadScene("Die");
    }
}
