using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leviers : MonoBehaviour
{
    private Interactable inter;
    private Animator animlevier;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        inter = GetComponent<Interactable>();
        animlevier = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.enabled = inter.state;
        animlevier.enabled = inter.state;
    }
}
