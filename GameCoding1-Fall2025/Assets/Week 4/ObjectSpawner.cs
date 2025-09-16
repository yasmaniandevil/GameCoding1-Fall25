using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //first make a gameobject prefab
    /*A Prefab in Unity is a reusable asset that serves as a template for GameObjects*. 
     * It allows you to save a GameObject, along with all its components, properties, 
     * and child GameObjects, as a single asset in your project*/
    //Used for instantiation
    public GameObject circlePrefab;
    public GameObject trianglePrefab;
    public GameObject hexPrefab;
    public Vector2 spawnPoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(circlePrefab, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //step 2
        //then instantiate
        //then make a spawn point variable
        //how do we stop it from instantiating forever? (we put it in start to spawn just one or we put it in a loop)
        //Instantiate(prefab, spawnPoint, Quaternion.identity);

        //lets do some examples with a key press
        //step 3
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(circlePrefab, spawnPoint, Quaternion.identity);
        }

        //step 5
        //could do on input press but also could call this function on collision or trigger
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnSimple();
        }

        //step 7
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnObject(trianglePrefab, spawnPoint, new Vector2(-3, 3), Color.blue);

           
        }

        //step 8
        if (Input.GetKeyDown(KeyCode.R))
        {
            //what if i want to make it random positions?
            //random.range (anywhere from first value, to second value)
            Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-4.4f, 4.4f));
            Vector2 randomScale = new Vector2(Random.Range(1, 5), Random.Range(1, 5));
            SpawnObject(hexPrefab, randomPos, randomScale, Color.green);

            //then we can add more variables at the top so we can swap even what we instantiate
            //SpawnObject(trianglePrefab, randomPos, randomScale, Color.yellow);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(bulletPrefab, new Vector3(2, 0, 0), Quaternion.identity);
        }
    }

    //step 6
    //function with param/arguments(interchangeable)
    /*Parameters: are variables declared within the parentheses of a function 
     * definition. They act as placeholders for the data the function expects to receive*/
    void SpawnObject(GameObject gameObject, Vector2 position, Vector2 scale, Color color)
    {
        //make a var that will hold our instantiated game object
        GameObject spawnedObj = Instantiate(gameObject, position, Quaternion.identity);
        //each of our new instantiated objects we are going to assign it to our scale parameter
        spawnedObj.transform.localScale = scale;
        //we are then gonna grab the sprite renderer off of our instantiated obj and assign it to our color param
        spawnedObj.GetComponent<SpriteRenderer>().color = color;
    }
     
    //step 4
    //example of writing a function with no parameters or arguments
    /*you would write this if you want to instantiate something you 
     * would call this function
    //and you do not need user input always*/
    void SpawnSimple()
    {
        //we give it our prefab
        //a spawn point
        //and no rotation
        Instantiate(circlePrefab, spawnPoint, Quaternion.identity);
    }
    
}
