using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indice : MonoBehaviour
{
    public glypheenigma enigma;
    public Material mat0;
    public Material mat1;
    public Material mat2;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enigma.enigm == 0)
            rend.material = mat0;
        if (enigma.enigm == 1)
            rend.material = mat1;
        if (enigma.enigm == 2)
            rend.material = mat2;
    }
}
