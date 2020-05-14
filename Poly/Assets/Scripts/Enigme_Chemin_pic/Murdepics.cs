using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murdepics : MonoBehaviour
{
    public GameObject plaquegauche;
    public GameObject plaquedroite;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Plateforme.plateformetrigger)
        {
            anim.SetBool("Trigger", true);
            plaquegauche.transform.Translate(Vector3.up * (Time.deltaTime * 0.5f));
            plaquedroite.transform.Translate(Vector3.up * (Time.deltaTime * 0.5f));
        }
        
    }
}
