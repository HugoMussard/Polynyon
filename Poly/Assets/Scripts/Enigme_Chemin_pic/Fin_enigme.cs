using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin_enigme : MonoBehaviour
{
    public Transform rocher;
    public GameObject smoke;
    public Spawn_script spawn_script;
    private Renderer rd;
    public GameObject camdie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        bouge();
    }

    void bouge()
    {
        rocher.Translate(Vector3.down * (Time.deltaTime * 1.0f));
    }
    
}
