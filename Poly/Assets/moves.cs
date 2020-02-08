using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moves : MonoBehaviour
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundis, groundmask);
        if (isgrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x+ transform.forward * z;

        control.Move(move*speed* Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isgrounded)
            velocity.y = Mathf.Sqrt(jumphigh * (-2f) * gravity);
			
		

    }
}
