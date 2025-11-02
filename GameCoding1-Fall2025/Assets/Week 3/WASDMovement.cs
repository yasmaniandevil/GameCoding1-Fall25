using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb2d;
    float currentSpeed;
    public float extraSpeed = 10;
    int jumpCount;
    public bool sprintOn = false;

    private int score;
    public TextMeshProUGUI scoreText;
    private int maxJumps = 2;

    // Start is called before the first frame update
    void Start()
    {
        /*A Rigidbody in Unity is a component that enables a GameObject 
         * to be controlled by the physics engine. When a Rigidbody component 
         * is added to a GameObject, that object can then be influenced by 
         * forces such as gravity, receive forces and torque through scripting, 
         * and interact with other physics-enabled objects in the scene through collisions.*/
        rb2d = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        //if the player hits space
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Debug.Log("hit space");
            //then we are going to keep the velocity on the x
            //and change the y to jump force
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            Debug.Log("Jump");
            jumpCount++;
        }

        //exercise can you make a sprinting button and if statement?
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = extraSpeed;
            sprintOn = true;
            rb2d.linearVelocity = new Vector2(horizontalInput * currentSpeed, verticalInput * currentSpeed);
        }
        
        {
            currentSpeed = speed;
            rb2d.linearVelocity = new Vector2(horizontalInput * currentSpeed, verticalInput * currentSpeed);
        }
        
        //if()

        //Debug.Log("current speed: " + currentSpeed);
    }

    //solid objects that bump into each other
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("I Hit: " + collision.gameObject.tag);

        //exercise Tag Check on Collision
        //can you check for a specific collision?
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit Wall");
            //currentSpeed = extraSpeed;
            //changeSpeed = true;
        }

        
        
    }

    void AddScore(int amt)
    {
        score += amt;
        //scoreText.text = "Score: " + score.ToString();
    }
    
    //objects that overlap
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I Triggered: " + collision.gameObject.name);

        //exercise
        //place an invisible trigger somewhere in the game
        //that moves the player position
        /*if (collision.gameObject.CompareTag("MovePlayer"))
        {
            transform.position = new Vector2(5, 8);
        }*/

        if (collision.gameObject.CompareTag("Coins"))
        {
            AddScore(1);
            scoreText.text = "Score: " + score.ToString();
            //Destroy(gameObject);
            Debug.Log(score);
        }
    }
    
    

}
