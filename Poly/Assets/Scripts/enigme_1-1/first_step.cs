using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class first_step : MonoBehaviour
{
    public Interactable button1;
    public Interactable button2;
    public Interactable button3;
    private Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button1.state || button2.state || button3.state)
        {
            coll.enabled = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("enigma1-1");
    }
}
