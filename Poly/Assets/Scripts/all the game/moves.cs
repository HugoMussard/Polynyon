﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private float sp = 0.1f;
    private float horizontal;



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
        string run = PlayerPrefs.GetString("run");

        KeyCode upCode = (KeyCode) Enum.Parse(typeof(KeyCode), up);
        KeyCode downCode = (KeyCode) Enum.Parse(typeof(KeyCode), down);
        KeyCode leftCode = (KeyCode) Enum.Parse(typeof(KeyCode), left);
        KeyCode rightCode = (KeyCode) Enum.Parse(typeof(KeyCode), right);
        KeyCode runCode = (KeyCode) Enum.Parse(typeof(KeyCode), run);
        
        if (!photonView.IsMine) return;

        horizontal = Input.GetAxis("Horizontal");
        Anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        Anim.SetFloat("horizontal", horizontal);
        
        
        

        isgrounded = Physics.CheckSphere(groundCheck.position, groundis, groundmask);
        if (isgrounded && velocity.y < 0)
            velocity.y = -2f;

        
        
        if (Input.GetKey(rightCode) && x < 1) x += 0.1f;
        else if (Input.GetKey(leftCode) && x > -1) x -= 0.1f;
        else if (x >= -0.1 && x <= 0.1) x = 0;
        else if (x > 0) x -= 0.1f;
        else if (x < 0) x += 0.1f;

        if (Input.GetKey(runCode))
        {
            speed = 12f;
            Anim.SetBool("Sprint", true);
        }    
        else
        {
            speed = 8f;
            Anim.SetBool("Sprint", false);
        }

        if (Input.GetKey(upCode) && z < 1) z += sp;
        else if (Input.GetKey(downCode) && z > -1) z -= sp;
        else if (z >= -0.1 && z <= 0.1) z = 0;
        else if (z > 0) z -= 0.1f;
        else if (z < 0) z += 0.1f;

        
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumphigh * (-2f) * gravity);
            Anim.SetBool("Jump", true);
        }
        else
        {
            Anim.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Anim.SetBool("Coucou", true);
        }
        else
        {
            Anim.SetBool("Coucou", false);
        }
        
        if (Input.GetKey(KeyCode.M))
        {
            Anim.SetBool("Macarena", true);
        }    
        else
        {
            Anim.SetBool("Macarena", false);
        }



        Vector3 move = transform.right * (float) x + transform.forward * (float) z;
        control.Move(move * (speed * Time.deltaTime));

        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
    }

}
