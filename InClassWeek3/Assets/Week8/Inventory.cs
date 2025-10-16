using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Inventory : MonoBehaviour
{
    //a list that stores the names of all the collected keys
    public List <string> collectedKeysList = new List<string> ();
    public TextMeshProUGUI inventoryText;

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
        if (collision.gameObject.CompareTag("Key"))
        {
            //add the key to our list
            //by adding its name
            collectedKeysList.Add(collision.gameObject.name);
            Destroy (collision.gameObject);
            //going to turn it into a string
            //print out each one we collected on a new line \n
            inventoryText.text = "Collected: \n " + string.Join("\n", collectedKeysList);
        }
    }

    //this function checks if the player has a specific key
    //it then returns true or false depending on if they have the right key
    //when a function does not have void that means it has to return something
    public bool HasKey(string keyName)
    {
        //.contains checks if our list has the value
        return collectedKeysList.Contains(keyName);
        
    }
}
