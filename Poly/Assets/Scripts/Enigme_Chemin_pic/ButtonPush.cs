using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public Transform button;
    public Interactable opener;
    public Transform Rosedesvents;

    void Start()
    {
        GameObject lightGameObject = new GameObject("The Light");
        
        Light lightComp = lightGameObject.AddComponent<Light>();
    }

    

    void Update()
    {
        if (opener.state)
        {
            if (button.position.z >= -21.353f)
            {
                button.transform.Translate(Vector3.up * (Time.deltaTime * 3.0f));
            }

            if (Rosedesvents.position.y <= 4)
            {
                Rosedesvents.Translate(Vector3.up * (Time.deltaTime * 1.5f));
            }
        }
    }
}
