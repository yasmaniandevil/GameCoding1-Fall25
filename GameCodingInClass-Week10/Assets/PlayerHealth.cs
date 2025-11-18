using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public TextMeshProUGUI livesText;

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
            if(shieldTimer >= shieldDuration )
            {
                isShielded = false;
                Debug.Log("shield expired");
            }
        }
        
    }

    public void UpdateText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    //this is the function we are going to call when we want our player to lose a life
    public void LoseLife()
    {
        lives--;
        UpdateText();
        if(lives <= 0)
        {
            //to prevent us from going into the negatives
            lives = 0;
            //i would call a die function here
            Debug.Log("Game Over");
        }
    }

    public void TakeDamage(int damage)
    {
        //if the player has a shield exit the function here, take no damage
        if (isShielded)
        {
            Debug.Log("player has shield");
            return;
        }
        lives -= damage;
        UpdateText();
        if(lives <= 0)
        {
            lives = 0;
            Debug.Log("Game Over");
        }
    }

    public void ActivateShield(float duration)
    {
        isShielded = true;
        shieldTimer = 0f;
        shieldDuration = duration;
    }

}
