using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colider_die : MonoBehaviour
{
    public Interactable button;
    Collider coll;
    void Start()
    {
        coll = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.state)
        {
            coll.isTrigger = true;
            coll.enabled = true;
        }
        else
        {
            coll.isTrigger = false;
            coll.enabled = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("enigma1-1");
    }
}
