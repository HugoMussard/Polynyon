using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grilles : MonoBehaviour
{
    Transform transf;
    public Interactable button;
    // Start is called before the first frame update
    void Start()
    {
        transf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.state)
            transf.position = new Vector3(transf.position.x, 8f, transf.position.z);
        else
            transf.position = new Vector3(transf.position.x, 1f, transf.position.z);
    }
}
