using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // a list that stores the names of all collected keys
    //declaring and initalizing it
    public List<string> collectedKeys = new List<string>();

    public TextMeshProUGUI text;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we collide with key
        if (collision.gameObject.CompareTag("Key"))
        {
            //add its name to our list
            collectedKeys.Add(collision.name);
            Debug.Log("Collected: " + collision.name);
            Destroy(collision.gameObject);
            text.text = "Collected:\n " + string.Join("\n", collectedKeys);
            
        }
    }

    //this function checks if the player has a specific key
    public bool HasKey(string keyName)
    {
        //.contains checks if our list has the value
        return collectedKeys.Contains(keyName);
    }
}
