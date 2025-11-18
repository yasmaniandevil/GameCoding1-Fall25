using System;
using UnityEngine;

public class SpeedBoostCollectible : MonoBehaviour
{
    public bool pickedUpSpeedBoost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCC playerScript = other.GetComponent<PlayerCC>();
        if (playerScript != null)
        {
            //playerScript.SpeedBoost();
            pickedUpSpeedBoost = true;
        }
    }
}
