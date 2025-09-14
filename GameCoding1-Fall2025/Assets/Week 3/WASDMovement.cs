using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb2d;
    float currentSpeed;
    public float extraSpeed = 10;
    int jumpCount;

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
        //unity input system
        //horizontal is mapped to a/d and left right
        //vertical is w/s and up and down
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        //access the velocity property of rigidbody
        //create a new vector 2 that multiplies the input by speed
        //horizontal input is either 1 or -1 depending on the key you press
        rb2d.velocity = new Vector2(horizontalInput * currentSpeed, verticalInput * currentSpeed);
        Debug.Log("current speed: " + currentSpeed);

        //if the player hits space
        if (Input.GetKey(KeyCode.Space))
        {
            //then we are going to keep the velocity on the x
            //and change the y to jump force
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        //exercise can you make a sprinting button and if statement?
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.velocity = new Vector2(horizontalInput * speed * 2, verticalInput * speed);
        }*/
    }

    //solid objects that bump into each other
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This function runs automatically when the object this
        //script is on collides with another object.

        //Collision2D represents the data from a 2D collision in unity
        //when unity detecs collision it creates a collision2d Obj that holds the info
        //collision is the name of the variable that will store
        //the Collision2D object when the method is triggered

        //think of it as a report
        //when we hit an object
        //unity will store what object we hit in our collision variable
        //and passes it into our method
        Debug.Log("I Hit: " + collision.gameObject.name);

        //exercise Tag Check on Collision
        //can you check for a specific collision?
        /*if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit Wall");
            //maybe when the player hits the wall it reverses or increases their velocity
        }*/

        currentSpeed = extraSpeed;
        Debug.Log("changespeed");
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
    }
}
