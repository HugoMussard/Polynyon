using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mdp4 : MonoBehaviour
{

    public Interactable red_butt;

    private bool check; 

    private Animator anim1; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim1 = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (red_butt.state && !check)
        {
            check = true; 
            anim1.SetBool("Mdp4_bool", true);
        }
    }
}
