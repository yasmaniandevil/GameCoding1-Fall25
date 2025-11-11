using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCC : MonoBehaviour
{
    public float walkSpeed = 5f;
    private Rigidbody2D rb;
    public float sprintSpeed = 8f;
    private Vector2 moveInput;
    public bool isSprinting;
    
    public float jumpForce = 5f;
    private int jumpCount;
    public int maxJumps = 2;
    
    public LayerMask groundLayer;
    public Transform groundCheck;

    public Transform defaultRespawn;

    private int playerLives = 3;

    public TextMeshProUGUI livesCounterText;

    private Transform currentRespawn;
    
    public List<GameObject> disappearingPlatforms = new List<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        //reset the jump count
        if (isGrounded())
        {
            jumpCount = 0;
        }

        Respawn();
    }

    private void FixedUpdate()
    {
        float currentSpeed;
        
        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
        
        rb.linearVelocity = new Vector2(moveInput.x * currentSpeed, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 horizontalInput = context.ReadValue<Vector2>();
        moveInput = new Vector2(horizontalInput.x, 0f);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //only jump when space is pressed
        //optional to only jump when player is grounded as well
        if (context.performed)
        {
            if (jumpCount < maxJumps)
            {
                //reset vertical velocity before jump for consitency?
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                //if we dont care about max jumps then just do this line inside the first if statement
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        //if we press the sprint key
        if (context.performed) isSprinting = true;
        if(context.canceled) isSprinting = false;
    }

    private void Respawn()
    {
        if (transform.position.y < -8 && !isGrounded())
        {
            Transform target;
            playerLives--;
            UpdateText();
            if (currentRespawn != null)
            {
                target = currentRespawn;
            }
            else
            {
                target  = defaultRespawn;
            }
        
            transform.position = target.position;
            rb.linearVelocity = Vector2.zero;

            foreach (GameObject platform in disappearingPlatforms )
            {
                platform.GetComponent<disapearPlatform>().ResetPlatform();
            }
        }
        
        
    }
    
    private void UpdateText()
    {
        livesCounterText.text = "Lives: " + playerLives;
    }
    
    public void UpdateRespawnPoint(Transform newRespawn)
    {
        currentRespawn = newRespawn;
    }
}
