using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anims_on_off : MonoBehaviour
{
    public Interactable inter;
    public Animator anim;
    public string boo;

    public void Update()
    {
        anim.SetBool(boo, inter.state);
    }
}
