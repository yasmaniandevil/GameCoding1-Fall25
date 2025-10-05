using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    //this is a script for "torodial" wall wrapping, which makes it look like the game edges loop
    //to achieve this, we need to teleport our player to the opposite wall when they touch a wall
    //manually assign the opposite wall in the inspector
    public GameObject OppositeWall;

    //and make a boolean that we check to see if the wall is vertical "true" or horizonal "false"
    public bool vertical;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when something runs into a wall,
        //check what the name on that object is. 
        // if it's Player1, or Player 2...

        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            //then get the bounds (size) of the box collider attached, which we'll need later to place our player
            Vector2 ColliderSize = collision.gameObject.GetComponent<BoxCollider2D>().bounds.size;

            //this is an integer that we'll use later in the code, to place our player correctly. it defaults to positive
            int PositiveOrNegative = 1;

            //if the walls are horizontal... 
            if (vertical == false)
            {

                //check if the opposite wall is the "up" wall (has a positive y axis) 
                if (OppositeWall.transform.position.y > 0)
                {
                    //if the opposite wall is up, this wall is down
                    //which means it is "negative"
                    PositiveOrNegative = -1;
                }

                //we now move our player to the opposite wall
                //we do this by keeping their x and z axis the same...
                //and changing the transform only on the y axis
                //however, we have to adjust the y axis by the size of our player's box collider (plus a little extra)
                //we do this so they don't immediately run into the other wall, triggerign the same script
                //we use the "positive or negative" number to check if they should be "up" or "down" from the wall by their width
                //this is because we always want them on the "inside" of the wall space!
                collision.gameObject.transform.position = new Vector3(
                    collision.gameObject.transform.position.x,
                    OppositeWall.transform.position.y + (ColliderSize.y + 0.1f) * PositiveOrNegative,
                    collision.gameObject.transform.position.z
                    );
            }
            //if the vertical IS true, we do the same process, but on the x axis instead of the y...
            else if (vertical == true)
            {
                if (OppositeWall.transform.position.x > 0)
                {
                    PositiveOrNegative = -1;
                }
                //note how the y and z components are the same
                //and it is the x that changes
                collision.gameObject.transform.position = new Vector3(
                    OppositeWall.transform.position.x + (ColliderSize.x + 0.1f) * PositiveOrNegative,
                    collision.gameObject.transform.position.y,
                    collision.gameObject.transform.position.z
                    );
            }
        }
    }

}
