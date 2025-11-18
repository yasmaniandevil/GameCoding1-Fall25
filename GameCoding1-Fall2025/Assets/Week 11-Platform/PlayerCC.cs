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
    private bool isFacingRight = true;
    
    public float jumpForce = 5f;
    private int jumpCount;
    public int maxJumps = 2;
    
    //collision detection vars
    public LayerMask groundLayer;
    public Transform groundCheck;

    //respawn variables
    public Transform defaultRespawn;
    private Transform currentRespawn;
    
    public PlayerHealth playerHealthScript;
    
    //shooting variables
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private float shootTimer = 0;
    public float shootInterval = 2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (playerHealthScript == null)
        {
            playerHealthScript = GetComponent<PlayerHealth>();
        }
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
        
        shootTimer += Time.deltaTime;
        
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
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = new Vector2(input.x, 0f);
        //convert from vector 2 to float
        float horizontalInput = input.x;
        //no movement no flip
        if (horizontalInput == 0f) return;
        
        if(horizontalInput > 0f && !isFacingRight) Flip();
        if(horizontalInput < 0f && isFacingRight) Flip();
        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale; 
        scale.x *= -1;
        transform.localScale = scale;
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

    //we need to change the respawn function to call from our player health script
    private void Respawn()
    {
        if (transform.position.y < -8 && !isGrounded())
        {
            //tell health system we need to lose a life
            if (playerHealthScript != null)
            {
                playerHealthScript.LoseLife();
            }
            
            //move player back to check point or default
            Transform target;
            
            if (currentRespawn != null)
            {
                target = currentRespawn;
            }
            else
            {
                target  = defaultRespawn;
            }
            transform.position = target.position;
            //stop velocity
            rb.linearVelocity = Vector2.zero;

            /*foreach (GameObject platform in disappearingPlatforms )
            {
                platform.GetComponent<disapearPlatform>().ResetPlatform();
            }*/
            
            GameManager.instance.RespawnPlatforms();
        }
        
        
    }
    /* move this to playerhealth
    private void UpdateText()
    {
        livesCounterText.text = "Lives: " + playerLives;
    }*/
    
    public void UpdateRespawnPoint(Transform newRespawn)
    {
        currentRespawn = newRespawn;
    }

    public void SpeedBoost()
    {
        
    }

    public void FireBullet()
    {
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            //set direction based on players facing direction
            float bulletDirection;
            if (isFacingRight)
            {
                 bulletDirection = 1f;
            }
            else
            {
                bulletDirection = -1f;
            }
            
            PlayerBulletPlatform playerBulletScript = bullet.GetComponent<PlayerBulletPlatform>();
            if (playerBulletScript != null)
            {
               playerBulletScript.SetDirection(bulletDirection);
            }
            
            Destroy(bullet, 5f);
        }
    }

    public void PressShoot(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (shootTimer >= shootInterval)
        {
            FireBullet();
            shootTimer = 0f;
        }
    }

    

    
}
