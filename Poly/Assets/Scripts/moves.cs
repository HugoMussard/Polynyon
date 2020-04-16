using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

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
    public GameObject parent;
    public Animator Anim;
    private double x = 0; 
    private double z = 0;
    


    private void Start()
    {
        parent.SetActive(photonView.IsMine);
    }
    

    void Update()
    {
        string up = PlayerPrefs.GetString("up");
        string down = PlayerPrefs.GetString("down");
        string left = PlayerPrefs.GetString("left");
        string right = PlayerPrefs.GetString("right"); 
        
        KeyCode upCode = (KeyCode) Enum.Parse(typeof(KeyCode), up);
        KeyCode downCode = (KeyCode) Enum.Parse(typeof(KeyCode), down);
        KeyCode leftCode = (KeyCode) Enum.Parse(typeof(KeyCode), left);
        KeyCode rightCode = (KeyCode) Enum.Parse(typeof(KeyCode), right);
        
        if (!photonView.IsMine) return;
        Anim.SetFloat("vertical", Input.GetAxis("Vertical"));

        
        isgrounded = Physics.CheckSphere(groundCheck.position, groundis, groundmask);
        if (isgrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetKey(rightCode) && x < 1) x += 0.1f; 
        else if (Input.GetKey(leftCode) && x > -1) x -= 0.1f;
        else if (x >= -0.1 && x <= 0.1) x = 0; 
        else if (x > 0) x -= 0.1f; 
        else if (x < 0) x += 0.1f; 
        
        
        if (Input.GetKey(upCode) && z < 1) z += 0.1f; 
        else if (Input.GetKey(downCode) && z > -1) z -= 0.1f;
        else if (z >= -0.1 && z <= 0.1) z = 0; 
        else if (z > 0) z -= 0.1f; 
        else if (z < 0) z += 0.1f; 
            
        Vector3 move = transform.right * (float) x + transform.forward * (float) z;
        control.Move(move * (speed * Time.deltaTime));
        
        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
     
        
        
        if (Input.GetKeyDown(KeyCode.T) && !(Anim.GetBool("isTackling")))
        {
            Anim.SetBool("isTackling", true);
        }
        else
        {
            Anim.SetBool("isTackling", false);
        }

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumphigh * (-2f) * gravity);
            Anim.SetBool("isJumping", true);
        }
        else
        {
            Anim.SetBool("isJumping", false);
        }



    }
}
