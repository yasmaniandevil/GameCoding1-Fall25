using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject[] collectiblePrefabs;
    //public List<Transform> spawnPoints;
    public Vector3[] spawnPosition;


    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < collectiblePrefabs.Length; i++)
        {
            Instantiate(collectiblePrefabs[i], spawnPosition[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
