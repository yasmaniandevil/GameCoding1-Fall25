using System;
using Unity.VisualScripting;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public float bounceForce = 3f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(("Player")))
        {
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            
            playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
