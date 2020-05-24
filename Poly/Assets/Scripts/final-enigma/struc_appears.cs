using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class struc_appears : MonoBehaviour
{
    private Animator anim;
    public GameObject obj;

    public void Start()
    {
        anim = obj.GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        anim.SetBool("open", true);
    }
    public void OnTriggerExit(Collider other)
    {
        anim.SetBool("open", false);
    }
}
