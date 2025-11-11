using System;
using UnityEngine;

public class disapearPlatform : MonoBehaviour
{
    public float disappearTime = 2f;
    public bool playerOnPlatform = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform)
        {
            disappearTime -= Time.deltaTime;
            if (disappearTime < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(("Player")))
        {
            playerOnPlatform = true;
        }
        else
        {
            playerOnPlatform = false;
        }
    }

    public void ResetPlatform()
    {
        gameObject.SetActive(true);
        disappearTime = 2f;
        playerOnPlatform = false;   
    }
}
