using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public int numberToSpawn = 4;
    public float spacing = 1.5f;
    public Vector2 startPos = new Vector2(-4, 2);

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for int i = 0; all we are doing is creating a var called i and setting it to 0
        //it is like writing at the top private int i = 0;
        //the second part is 0 less than whatever number we give our numberToSpawn variable
        //so for right now it is 0 less than 4
        //i++ means adds 1. so its i + 1
        //this is a for loop, it will run 4 times which means it will spawn our pickupPrefab 4 times
        for(int i = 0; i < numberToSpawn; i++)
        {
            //first we create a new vector 2
            //that takes the start position and multiplies it by spacing 
            Vector2 pos = new Vector2(startPos.x + i * spacing, startPos.y);
            Debug.Log("spacing position:" + startPos.x + i);
            //and then we instantiate it, everytime it runs a new position is calculated 
            //that takes into account the last thing we spawned and multipes by spacing to create distance
            Instantiate(pickupPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
