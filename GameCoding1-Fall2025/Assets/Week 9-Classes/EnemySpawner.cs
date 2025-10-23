using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabList;
    public float spawnInterval;
    //horizontal range for spawning enemies
    public float spawnRangeX = 7;
    //defines radius around spawn point
    public float spawnRadius = 2f;

    private float spawnTimer = 0;
    //how many enemies can appear at once
    public int maxEnemies = 4;

    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && GetEnemyCount() < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabList.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 3);

        if (isSpawnClear(spawnPos))
        {
            Instantiate(enemyPrefabList[randomIndex], spawnPos, Quaternion.identity);
            Debug.Log("spawn enemy");
        }
        else
        {
            Debug.Log("spawn pos is blocked");
        }
        
    }

    bool isSpawnClear(Vector2 position)
    {
        //check for enemies within spawn radius (their colliders)
        //if no colliders are found it returns true
        Collider2D hitCollider = Physics2D.OverlapCircle(position, spawnRadius, enemyLayer);
        //if no collider is found the position is clear
        return hitCollider == null;
    }

    int GetEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
