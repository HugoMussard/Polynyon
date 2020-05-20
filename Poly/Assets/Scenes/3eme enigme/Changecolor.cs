using System.Collections;
using System.Collections.Generic;
using agora_gaming_rtc;
using UnityEngine;

public class Changecolor : MonoBehaviour
{
    GameObject cube;
    Animator anim;
    public Interactable cube1;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (cube1.state)
        {
            anim.SetBool("Push", true);
            StartCoroutine(DoTheDance());
        }
    }
    
    public IEnumerator DoTheDance() 
    {
        yield return new WaitForSeconds(2f);
        Yellow();    
        yield return new WaitForSeconds(2f);
        Green();
        yield return new WaitForSeconds(2f);
        Blue();
        yield return new WaitForSeconds(2f);
        White();

    }

    void White()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.white;
    }

    void Red()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }
    void Blue()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.blue;
    }
    
    void Yellow()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.yellow;
    }

    void Green()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }
    
}
