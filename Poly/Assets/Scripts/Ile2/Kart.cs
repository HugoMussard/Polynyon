using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{

    public GameObject levier;

    public bool check;

    public GameObject kart2;

    public GameObject new_pos;

    private Animator anim1; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim1 = levier.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (levier.GetComponent<Interactable>().state && !check)
        {
            anim1.SetBool("Kart_bool", true);
            check = true;
            kart2.transform.position = new_pos.transform.position; 
        }
    }
}
