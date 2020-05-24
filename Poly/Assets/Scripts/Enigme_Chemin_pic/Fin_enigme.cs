using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin_enigme : MonoBehaviour
{
    private Animator anim;
    public GameObject rocher;

    // Start is called before the first frame update
    void Start()
    {
        anim = rocher.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Fini", true);
    }    
    
    
}
