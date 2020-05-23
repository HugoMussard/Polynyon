using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public bool appear;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        appear = false;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.enabled = appear;
    }
}
