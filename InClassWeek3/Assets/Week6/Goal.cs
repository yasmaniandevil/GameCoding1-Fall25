using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{

    //two public booleans, which we can use to assign "which" goal this script is attached to...
    public bool Player1Goal;
    public bool Player2Goal;

    //the text that we want to use to display the score
    public TMP_Text DisplayScore;

    //the canvas that contains our game over screen
    public GameObject GameOverScreen;

    //the piece of text that will display who won
    public TMP_Text WinDisplay;

    //the score starts at zero
    private int score = 0;

    //we need to reach 3 to win
    private int scoreToWin = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //we MAKE SURE that the game over screen is set to inactive at the start of the games
        GameOverScreen.SetActive(false);
    }

    //this function is called when we collide with a game object with a collider 2d on it WITH "IS TRIGGER" CLICKED
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the object we've triggered is named "Ball"
        if (collision.gameObject.name == "Ball")
        {
            //if the current score is less than the score needed to win...
            if (score < scoreToWin)
            {
                //then we put the ball, which collided with a goal, at the 0,0,0 point (center)
                collision.gameObject.transform.position = new Vector3(0, 0, 0);

                //and we reset the ball's linear velocity to zero
                collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;

                //then we increment our score variable up
                score++;

                //and we update the score text on our canvas
                //we are "adding" an empty string here so that it converts the number to a string!
                DisplayScore.text = score + "";
            }
            //now, if the score is greater than or equal to the score needed to win...
            if (score >= scoreToWin)
        {
            //we check which goal the script is attached to...
            if (Player1Goal == true)
            {
                //and change which player the screen displays as winning
                WinDisplay.text = "Player 1 Wins!";
            }
            else if (Player2Goal == true)
            {
                WinDisplay.text = "Player 2 Wins!";
            }
            //then we set the canvas with our game over screen on it to active
            //this contains the button to restart the gamess
            GameOverScreen.SetActive(true);
        }
    }

    }
}
