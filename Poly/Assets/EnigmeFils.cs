using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeFils : MonoBehaviour
{
    public Interactable opener;

    public Material material;

    public Material material_principal; 

    public GameObject Symb1;

    public GameObject Symb2;

    public void Start()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1);
        material_principal.color = new Color(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        if (opener.state && material.color.a == 1)
            if (CableValid())
            {
                material.color = new Color(material.color.r, material.color.g, material.color.b, 0);
                material_principal.color = new Color(0, 0.5f, 0);
            }
    }

    private bool CableValid()
    {
        if (Symb1.activeSelf && Symb2.activeSelf)
        {
            if (material.color.b == 1)
                return true;
        }
        else 
        {
            if (material.color.r == 1)
                    return true;
        }
        return false;
    }
}
