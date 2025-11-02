using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeek8 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5;

    public Animator animator;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");

      
        
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);


        if (context.canceled)
        {
            animator.SetBool(("isWalking"), false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        
        animator.SetFloat("currentInputX", moveInput.x);
        animator.SetFloat("currentInputY", moveInput.y);
        
    }
}
