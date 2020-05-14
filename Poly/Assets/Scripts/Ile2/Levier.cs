using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{

    public Interactable Interactable;

    
    // Start is called before the first frame updat
 

    // Update is called once per frame
    void Update()
    {
        if (Interactable.state && transform.rotation.eulerAngles.x > 310) transform.Rotate(new Vector3(-60.0f, 0, 0) * (Time.deltaTime * 1.0f));
        ;
    }
}
