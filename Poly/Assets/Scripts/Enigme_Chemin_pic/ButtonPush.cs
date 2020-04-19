using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public Transform button;
    public Interactable opener;

    public Transform Rosedesvents;
    // Update is called once per frame
    void Update()
    {
        if (opener.state)
        {
            if (button.position.z >= -21.67f)
            {
                button.transform.Translate(Vector3.up * (Time.deltaTime * 3.0f));
            }

            if (Rosedesvents.position.y <= 4)
            {
                Rosedesvents.Translate(Vector3.up * (Time.deltaTime * 1.5f));
            }
        }
    }
}
