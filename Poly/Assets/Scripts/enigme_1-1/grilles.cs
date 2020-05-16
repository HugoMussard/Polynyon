using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class grilles : MonoBehaviour
{
    Transform transf;
    public Interactable button;
    public Interactable button2;
    // Start is called before the first frame update
    void Start()
    {
        transf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.state && button2.state)
            transf.position = new Vector3(transf.position.x, 8f, transf.position.z);

    }
}
