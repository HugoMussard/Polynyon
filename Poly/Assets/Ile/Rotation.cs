using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f);

    }
}
