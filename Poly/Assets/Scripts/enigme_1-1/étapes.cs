using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class étapes : MonoBehaviour
{
    // Start is called before the first frame update
    public Interactable butt1;
    public Interactable butt2;
    public Interactable butt3;
    Collider coll;

    public void Start()
    {
        coll = GetComponent<Collider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        butt1.state = false;
        butt2.state = false;
        butt3.state = false;
        coll.isTrigger = false;
    }
}
