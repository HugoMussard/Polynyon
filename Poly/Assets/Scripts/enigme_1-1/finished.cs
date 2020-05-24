using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finished : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("1-2", 1);
        PlayerPrefs.Save();
    }
}
