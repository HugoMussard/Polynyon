using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savefinished : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("1-1", 1);
        PlayerPrefs.Save();
    }
}
