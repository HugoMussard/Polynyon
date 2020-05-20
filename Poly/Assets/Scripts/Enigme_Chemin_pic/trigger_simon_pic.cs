using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger_simon_pic : MonoBehaviour
{
    Animator anim;

    public GameObject pics;
    // Start is called before the first frame update
    void Start()
    {
        anim = pics.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Spike", true);
    }
    
}
