using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    //reference for the player move script
    public TwoPlayerMove playerMoveScript;
    //how fast the boost is
    public float boostedSpeed;
    //how long the boost lasts
    public float durationSeconds;
    public TextMeshProUGUI countdownText;
    //check if boost is currently active
    private bool isBoostActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBoost()
    {
        //only start the boost if one is not already running
        if (!isBoostActive)
        {
            StartCoroutine(BoostRoutine());
        }
    }
    
    private IEnumerator BoostRoutine()
    {
        //mark the boost active
        isBoostActive = true;
        
        //save the players normal speed so we can reset it later
        float originalSpeed = playerMoveScript.speed;
        //set the new boosted speed
        playerMoveScript.speed = boostedSpeed;
        //track how much time is left
        float timeLeft = durationSeconds;
        
        //the while loop will keep running as long as timeleft is greater than 0
        while (timeLeft > 0)
        {
            //if we assigned the text in inspector then update it
            if (countdownText != null)
            {
                countdownText.text = "Boost: " + Mathf.Ceil(timeLeft);
            }
            //wait one frame before looping again
            yield return null;
            
            //subtract the time that passed since last frame
            timeLeft -= Time.deltaTime;
        }
        
        //the loop is finished timeLeft is 0 or less
        //reset the players speed to the original value
        playerMoveScript.speed = originalSpeed;

        if (countdownText != null)
        {
            countdownText.text = "";
        }
        
        //markt hat the boost is finished
        isBoostActive = false;
        
        Debug.Log("boost is finished");
    }
}
