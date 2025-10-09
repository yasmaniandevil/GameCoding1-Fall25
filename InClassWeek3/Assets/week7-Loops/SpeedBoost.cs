using System.Collections;
using TMPro;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    //in order to do speed boost we need access to the players speed which is in our player script
    //we have to create a reference to that script to access the players speed
    //we are making a variable of a script
    public TwoPlayerMove twoPlayerScript;
    //how fast the boost is
    public float boostedSpeed;
    //how long the boost lasts
    public float durationSeconds;
    //lets do a countdown timer text
    public TextMeshProUGUI countdownText;
    //check if boost is currently active
    private bool isBoostActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ActivateBoost()
    {
        //if the boost is not active aka FALSE
        //because we only want to start the boost if one is not already running
        if(!isBoostActive)
        {
            StartCoroutine(Boost());
        }
    }
    //IEnumerator is a coroutine which is a function that can be paused
    //it is used a lot for timers, cooldowns, timing specific actions
    private IEnumerator Boost()
    {
        //mark the boost active
        isBoostActive = true;

        //save the players normal speed so we can reset it later
        float originalSpeed = twoPlayerScript.speed;
        //set the new boosted speed
        twoPlayerScript.speed = boostedSpeed;
        //track how much time is left
        float timeLeft = durationSeconds;

        //the while loop will keep running as long as timeLeft is greater than 0
        while (timeLeft > 0)
        {
            //if the countdown text exists, if we gave it something in the inspector than we can change the text
            //this is done to prevent an error that says you didnt assign something in the inspector
            if(countdownText != null)
            {
                //so we are setting the text to display how much time is left
                countdownText.text = "Boost: " + Mathf.Ceil(timeLeft);
            }

            yield return null;

            //subtract the time that passed since the last frame
            timeLeft -= Time.deltaTime;
        }

        //the loop is finished timeLeft is 0 or less
        //reset the players speed to the original value
        twoPlayerScript.speed = originalSpeed;

        //check to see if it is assigned in the inspector
        if(countdownText != null)
        {
            //if it is then change the text
            countdownText.text = "Boost Over";
        }

        //mark that the boost has finished
        isBoostActive = false;

        Debug.Log("Boost has finished!");


    }
}
