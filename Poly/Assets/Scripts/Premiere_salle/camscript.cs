using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 

public class camscript : MonoBehaviourPunCallbacks
{
    public float sensi = 100f;
    public Transform player;
    private float xrotation = 0f;

    
    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return; 
        float mousex = Input.GetAxis("Mouse X") * sensi * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        player.Rotate(Vector3.up * mousex); 
    }
}
