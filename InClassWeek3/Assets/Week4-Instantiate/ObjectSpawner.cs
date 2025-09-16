using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //this varabile will hold our prefab game object
    public GameObject circlePrefab;
    public GameObject trianglePrefab;
    public GameObject hexPrefab;
    public GameObject bulletPrefab;

    public Vector2 spawnPoint;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //instantiation means spawning a game object
        //we are going to spawn it at the position of the script
        //quaternion.identity means we do not want rotation
        Instantiate(circlePrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(circlePrefab, spawnPoint, Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            SpawnSimple();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            //we made a function that has parameters inside of it
            //we are passing them in our function
            SpawnObjectComplex(hexPrefab, spawnPoint, new Vector2(3, 3), Color.violet);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            //what if we want to randomly position our prefab?
            //what if we wanted the scale to be random?
            //vector2(x, y) the first random range is anywhere on the x between -8 and 8
            //the y random range is between -4.5 - 4.5
            Vector2 randomPos = new Vector2(Random.Range(-8, 8), Random.Range(-4.5f, 4.5f));
            //now we are making a new local variable called randomScale and assigning it a random range
            Vector2 randomScale = new Vector2(Random.Range(1, 5), Random.Range(1, 5));
            Color randomColor = Random.ColorHSV();
            SpawnObjectComplex(hexPrefab, randomPos, randomScale, randomColor);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    //we are making a function where we instantiate something and then call it in update on key press
    void SpawnSimple()
    {
        //now we are spawning but we are hard coding where we want it to spawn to
        Instantiate(trianglePrefab, new Vector2(5, -3), Quaternion.identity);
    }

    void SpawnObjectComplex(GameObject gameObject, Vector2 pos, Vector2 scale, Color color)
    {
        //we first made a new variable of type game object
        //to store the game object that we instantiate 
        GameObject spawnedObj = Instantiate(gameObject, pos, Quaternion.identity);
        spawnedObj.transform.localScale = scale;
        spawnedObj.GetComponent<SpriteRenderer>().color = color;
        
    }
}
