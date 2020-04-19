using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gohub : MonoBehaviour
{
    public LayerMask hub;
    public float groundis = 0.5f;
    public Transform Hubcheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(Hubcheck.position, groundis, hub))
        {
            SceneManager.LoadSceneAsync(13);
            SceneManager.UnloadSceneAsync(12);
        }
    }
}
