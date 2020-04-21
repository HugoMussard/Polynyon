using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactonoff : MonoBehaviour
{
    public Renderer rend;
    public Interactable obj;
    public Material turnon;
    public Material turnoff;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        string name = obj.name;

    }

    // Update is called once per frame
    void Update()
    {
        if (obj.state)
        {
            rend.material = turnon;
        }
        else
        {
            rend.material = turnoff;
            
        }
    }
}
