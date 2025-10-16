using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //so we are making two arrays one of game objects and one of vector3s of where we want to spawn those gameobjects
    public GameObject[] collectiblesPrefabs;
    public Vector3[] spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this is going to loop over the array
        //the legnth of the array
        for(int i = 0; i < collectiblesPrefabs.Length; i++)
        {
            Instantiate(collectiblesPrefabs[i], spawnPosition[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
