using UnityEngine;

public class Door : MonoBehaviour
{
    //what is the required key name to open the door
    public string requiredKeyName;
    private bool isOpen = false;
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
        //only check if the player touches the door
        if (collision.gameObject.CompareTag("Player"))
        {
            //we grab the script off of the player (which is the collision in this case)
            Inventory inventory = collision.gameObject.GetComponent<Inventory>();

            //if we grabbed the inventory script
            //and it has the required key name to open the door
            if(inventory != null && inventory.HasKey(requiredKeyName))
            {
                Debug.Log("Door Opened With: " + requiredKeyName);
                OpenDoor();
                //grabbibg the text from the inventory script
                inventory.inventoryText.text = "Door Opened With: " + requiredKeyName;
            }
            else
            {
                Debug.Log("You need the" + requiredKeyName + "to open this door");
            }
        }
    }

    void OpenDoor()
    {
        //if we have not opened the door
        //if isOpen is false
        if (!isOpen)
        {
            isOpen = true;

            //challenge: can you change the color of the door when it opens
            SpriteRenderer doorColor = GetComponent<SpriteRenderer>();
            doorColor.color = Color.white;
        }
    }
}
