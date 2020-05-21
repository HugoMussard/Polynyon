using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigmas_finished : MonoBehaviour
{
    private Animator anim;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        anim = Door.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("1-1",0) != 0)
            anim.enabled = true;
    }
    void Update()
    {
        
    }
}
