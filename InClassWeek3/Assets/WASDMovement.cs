using TMPro;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody2D rb2D;
    public float jumpForce;

    //score variables
    private int score;
    //text that displays the score
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rigibody in unity is a component that enables a gameobject
        //it is controlled by the physics engine
        //when it is added to a game object it can use force, gravity, and receive forced
        //and it can interact with OTHER physics enabled objects through collisions
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //unitys "old" inout system
        //horizontal is mapped to left/right arrow and a/d key
        //getting the axis called horizontal and storing it inside our variable
        float horizontalInput = Input.GetAxis("Horizontal");
        //vertical is mapped to w/s and up and down keys
        float verticalInput = Input.GetAxis("Vertical");

        // vector2 (x, y)
        //4 = 2+2
        //accessing the linear velocity of our rigidbody
        //creats a new vector 2 that multiplies input by the speed
        //horizontal/vertical input is either 1 or -1 depending on the key you pressed
        rb2D.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        //if the player hits space
        if (Input.GetKey(KeyCode.Space))
        {
            //then we are going to jump
            //we are going to keep the velocity on the x and change the y to jump force
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }

        //can you make a sprinting button?
        //if get key
        //make player faster
    }

    //think of it as a report
    //when we hit an object
    //unity will store what object we hit in our collision var
    //then it passes it in to our method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I Hit: " + collision.gameObject.name);
        //can you check for a specific collision
        //compare tag again
        //if it is this tag
        //then increase player velocity

        if (collision.gameObject.CompareTag("Wall"))
        {
            rb2D.linearVelocity += new Vector2(20, 20);
        }
    }

    //objects that overlap and trigger a behavior 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I triggered: " + collision.gameObject.name);
        //place an insivible trigger somewhere in the game that moves the players position
        //compare tag
        //transform.position

        //if the player triggers a coin
        if (collision.gameObject.CompareTag("Coins"))
        {
            //add to our score
            AddScore(1);
            //and then print out our score
            scoreText.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
        }

        /*if (collision.gameObject.CompareTag("SuperCoins"))
        {
            AddScore(5);

        }*/
    }

    private void AddScore(int amount)
    {
        //it takes the score and adds the amount back into it
        score += amount;
    }

}
