using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_solved : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("1-3", 1);
        PlayerPrefs.Save();
    }
}
