using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moves_p2 : MonoBehaviour
{
    public CharacterController control;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundis = 1.5f;
    public LayerMask groundmask;
    public bool isgrounded;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundis, groundmask);
        if (isgrounded && velocity.y < 0)
            velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
        
        
        
    }
}
