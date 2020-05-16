using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    public Interactable inter;
    float time;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time == 0 && inter.state)
            time = Time.realtimeSinceStartup;
        if (Time.realtimeSinceStartup - time >= 3)
            inter.state = false;
        if (inter.state)
            light.enabled = true;
        else
        {
            light.enabled = false;
            time = 0f;
        }
    }
}
