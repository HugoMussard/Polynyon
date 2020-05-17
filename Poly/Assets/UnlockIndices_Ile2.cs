using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockIndices_Ile2 : MonoBehaviour
{
    public int nb;

    public GameObject porte;
    public GameObject trappe;
    public GameObject planches; 


    // Update is called once per frame
    void Update()
    {
        if (nb == 1)
        {
            Debug.Log("zee");
            if (porte.transform.rotation.eulerAngles.x < 310) 
                porte.transform.Rotate(new Vector3(-60.0f, 0, 0) * (Time.deltaTime * 1.0f)); 
            else nb = 0;
        }

        if (nb == 2)
        {
            Debug.Log("mamene");
            nb = 0; 
        }

        if (nb == 3)
        {
            
        }
    }
}
