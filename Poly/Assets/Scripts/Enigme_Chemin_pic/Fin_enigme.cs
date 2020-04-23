using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin_enigme : MonoBehaviour
{
    public Transform rocher;
    private bool bouge;
    
    // Start is called before the first frame update
    void Start()
    {
        bouge = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bouge)
        {
            rocher.Translate(Vector3.down * (Time.deltaTime * 1.0f));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        bouge = true;
    }
    
}
