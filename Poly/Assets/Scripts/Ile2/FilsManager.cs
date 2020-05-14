using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System;
using Random = System.Random;

public class FilsManager : MonoBehaviour
{
    public Material material_principal;


    // Start is called before the first frame update
    void Start()
    {
        material_principal.color = new Color(1, 1, 1);
    }

}
