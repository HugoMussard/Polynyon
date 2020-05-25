using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish1_4 : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("1-4", 1);
    }
}
