using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 

public class moves : MonoBehaviourPunCallbacks
{
    public CharacterController control;

    public float speed = 8f;

    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundis = 1.5f;
    public LayerMask groundmask;
    public bool isgrounded;
    public Vector3 velocity;
    public float jumphigh = 3f;
    // Start is called before the first frame update
    public float sensi = 100f;
    public GameObject Cameraparent; 
    public Camera camera; 
    public Transform player;

    private float xrotation = 0f;
    
    private float yrotation = 0f;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cameraparent.SetActive(photonView.IsMine);
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (!photonView.IsMine) return; 
        
        //MouvCam
        float mousex = Input.GetAxis("Mouse X") * sensi * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        
        yrotation += mousex;
        yrotation = Mathf.Clamp(yrotation, -180f, 180f);

        camera.transform.localRotation = Quaternion.Euler(xrotation, yrotation, 0f);
        player.Rotate(Vector3.up * mousex);
        
        
        
        //Deplacement 
        isgrounded = Physics.CheckSphere(groundCheck.position, groundis, groundmask);
            if (isgrounded && velocity.y < 0)
                velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        
        control.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        control.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgrounded)
            velocity.y = Mathf.Sqrt(jumphigh * (-2f) * gravity);
    }
}
