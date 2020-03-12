using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 

public class Interaction : MonoBehaviourPunCallbacks
{
    public Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 position = transform.position;

            
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                Vector3 interact = interactable.transform.position;
                #region check if pos is valid
                Vector3 diff = position - interact;
                if (diff.x<0)
                {
                    diff.x *= -1;
                }
                if (diff.z < 0)
                {
                    diff.z *= -1;
                }
                if (diff.y < 0)
                {
                    diff.y *= -1;
                }
                #endregion
                if (interactable != null)
                {
                    float rad = interactable.radius;
                    if (diff.x<rad && diff.y<rad && diff.z <rad)
                        interactable.state = true;
                }
            }
        }
        
    }
}
