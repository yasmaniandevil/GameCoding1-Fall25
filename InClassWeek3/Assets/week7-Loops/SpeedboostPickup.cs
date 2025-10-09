using UnityEngine;

public class SpeedboostPickup : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //so when the player and pickup item collide we are going to grab the boostScript off of it so we can access it
        SpeedBoost boostScript = collision.GetComponent<SpeedBoost>();

        //if the script exists (if we were able to grab it)
        if(boostScript != null )
        {
            //call the activate boost function from the boost script
            boostScript.ActivateBoost();
            //so destroy the pickup which is this gameobject that the script is on
            Destroy(gameObject);
        }
    }
}
