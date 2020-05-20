using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigmas_finished : MonoBehaviour
{
    public Animator anim;
    public GameObject Door;
    public Spawn_script spawn;
    // Start is called before the first frame update
    void Start()
    {
        anim = Door.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("finished_enigmas", true);
    }
    void Update()
    {
        
    }
}
