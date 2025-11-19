using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKeyName;
    private bool isOpen = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //only check if the player touches the door
        if (collision.gameObject.CompareTag("Player"))
        {
            //get players inventory component
            Inventory inventory = collision.GetComponent<Inventory>();

            //if it found and assigned inventory
            //haskey returns all the names of the keys we collected
            //if we have right key
            //then will open the door
            if ((inventory != null && inventory.HasKey(requiredKeyName)))
            {
                Debug.Log("Door Opened with: " + requiredKeyName);
                OpenDoor();
                //challenge: can they do text by themselves?
                inventory.text.text = "Door Opened with: " + requiredKeyName;
            }
            else
            {
                Debug.Log("You need the" + requiredKeyName + "to open this door");
            }
        }
    }

    void OpenDoor()
    {
        if(!isOpen)
        {
            //destroy door when it opens
            //Destroy(gameObject);
            isOpen = true;
            
            //challenge: can they change the color of the door by themselves?
            SpriteRenderer spriteRendy = GetComponent<SpriteRenderer>();
            spriteRendy.color = Color.white;
        }
    }
}
