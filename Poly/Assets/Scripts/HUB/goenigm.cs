using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goenigm : MonoBehaviour
{
    public bool state = false;
    public Renderer rend;
    public Material off;
    public Material on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider collider)
    {
        state = true;
        rend.material = on; 
    }

    private void OnTriggerExit(Collider other)
    {
        state = false;
        rend.material = off;
    }



}
