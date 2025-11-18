using System;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerLives = 3;

    public TextMeshProUGUI livesCounterText;

    private bool isShielded = false;
    private float shieldTimer = 0f;
    private float shieldDuration;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShielded)
        {
            shieldTimer += Time.deltaTime;
            if (shieldTimer >= shieldDuration)
            {
                isShielded = false;
                Debug.Log("shield expired");
            }
        }
    }

    public void LoseLife()
    {
        playerLives--;
        UpdateText();
        if (playerLives <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    
    public void UpdateText()
    {
        if (livesCounterText != null)
        {
            livesCounterText.text = "Lives: " + playerLives;
            
        }
    }
    
    public void TakeDamage(int damage)
    {
        //if we are shielded we aren't going to take damage
        if (isShielded)
        {
            Debug.Log("player has shield");
            return;
        }
        
        playerLives -= damage;
        UpdateText();
        
        if (playerLives <= 0)
        {
            
            Debug.Log("Game Over");
            //probably want a die function
        }
    }

    public void ActivateShield(float duration)
    {
        isShielded = true;
        shieldTimer = 0f;
        shieldDuration = duration;
    }
}
