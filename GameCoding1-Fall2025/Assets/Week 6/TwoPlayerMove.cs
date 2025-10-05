using UnityEngine;

public class TwoPlayerMove : MonoBehaviour
{
    //reference rigidbody on player
    private Rigidbody2D rb2D;

    //set a movement speed
    public float speed = 4f;

    //a variable we make to check if the player is currently moving
    private bool isMoving = false;

    //which player is this? we can set this in the inspector, and use different movement code for each
    public int PlayerNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if we set our player to "1"..
        if (PlayerNumber == 1)
        {
            //then call the function WASDMovement
            WASDMovement();
        }
        //otherwise if our player is set to 2...
        else if (PlayerNumber == 2)
        {
            //call the arrow movement function
            ArrowMovement();
        }
    }


    private void WASDMovement()
    {
        //set isMoving to false at the top of this function
        isMoving = false;
        //check if key code is W
        if (Input.GetKey(KeyCode.W))
        {
            //give the player a "positive" (up) push on the y axis
            //they keep their CURRENT linear velocity on the x axis
            rb2D.velocity = new Vector2(rb2D.velocity.x, speed);
            //and set moving to true
            isMoving = true;
        }
        //keep checking 
        if (Input.GetKey(KeyCode.A))
        {
            //if the key is A, we want them to go left
            //that's a negative push on the x axis
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            isMoving = true;
        }
        //same check, but going "down"
        if (Input.GetKey(KeyCode.S))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -speed);
            isMoving = true;
        }
        //and right
        if (Input.GetKey(KeyCode.D))
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            isMoving = true;
        }
        //after all this, if a key hasn't been pressed, and the player isn't moving...
        else if (isMoving != true)
        {
            //make their linearvelocity zero
            rb2D.velocity = new Vector2(0, 0);
        }
    }
    

//this is the same code, but done with arrow keys instead~!
    private void ArrowMovement()
    {
        isMoving = false;
        //check if key code is up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, speed);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -speed);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            isMoving = true;
        }
        else if (isMoving != true)
        {
            rb2D.velocity = new Vector2(0, 0);
        }
    }
}
