using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    Killing killing;
    Collider bloc;
    public Interactable button;
    // Start is called before the first frame update
    void Start()
    {
        killing = GetComponent<Killing>();
        bloc = GetComponent<Collider>();
        killing.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       killing.enabled = button.state;
       bloc.enabled = button.state;
    }
}
