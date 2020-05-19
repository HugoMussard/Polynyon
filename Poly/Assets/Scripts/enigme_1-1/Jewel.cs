using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    public Interactable inter;
    public Light light;
    void Update()
    {
        light.enabled = inter.state;
    }
}
