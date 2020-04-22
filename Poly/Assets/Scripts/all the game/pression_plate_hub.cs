using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pression_plate_hub : MonoBehaviour
{
    public Renderer rend;
    public Material on;
    public Material off;
    void Start()
    {
        rend = GetComponent<Renderer>();

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.isTrigger)
            rend.material = on;
        else
            rend.material = off;
    }
}
