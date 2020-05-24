using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_trig : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        anim.enabled = true;
    }
}
