using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    GameObject sphere;
    public Interactable blue;
    public Interactable green;
    public Interactable yellow;
    public Interactable red;
    Animator ablue;
    Animator agreen;
    Animator ayellow;
    Animator ared;
    
    // Start is called before the first frame update
    void Start()
    {
        ablue = blue.GetComponent<Animator>();
        agreen = green.GetComponent<Animator>();
        ayellow = yellow.GetComponent<Animator>();
        ared = red.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (red.state)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = Color.red;
            ared.SetBool("red", true);
            agreen.SetBool("green", false);
            ayellow.SetBool("yellow", false);
            ablue.SetBool("blue", false);
        }

        if (green.state)
        {
            agreen.SetBool("green", true);
            ared.SetBool("red", false);
            ayellow.SetBool("yellow", false);
            ablue.SetBool("blue", false);
        }

        if (yellow.state)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = Color.white;
            ayellow.SetBool("yellow", true);
            ared.SetBool("red", false);
            agreen.SetBool("green", false);
            ablue.SetBool("blue", false);
        }

        if (blue.state)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = Color.green;
            ablue.SetBool("blue", true);
            ared.SetBool("red", false);
            agreen.SetBool("green", false);
            ayellow.SetBool("yellow", false);
        }
        
        
        
    }
}
