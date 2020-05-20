using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outofbound : MonoBehaviour
{
    private Vector3 posinit;
    private Vector3 posnow;
    public Transform trans;
    private Quaternion rotate;
    // Start is called before the first frame update
    void Start()
    {
        posinit = GetComponent<Transform>().position;
        rotate = new Quaternion(0, 0, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        posnow = GetComponent<Transform>().position;
        if (posnow.y <= -500f)
        {
            trans.SetPositionAndRotation(posinit,rotate);
        }
    }
}
