using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesList;
    public float spawnInterval;
    public float spawnRange = 7;
    //defines radius around spawnpoint
    public float spawnRadius = 2f;
    private float spawnTimer = 0;
    //how many enemies can appear at once
    public int maxEnemies = 4;
    public LayerMask enemyLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        //if we can shoot and if enemy count is less than max enemies because we don't wanna spawn too many enemies
        if(spawnTimer >= spawnInterval && GetEnemyCount() < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    void SpawnEnemy()
    {
        //we want to spawn enemies randomly, spawn from 0 to the length of our enemy list
        int randomIndex = Random.Range(0, enemiesList.Length);
        //anywhere from neg 7 to pos 7 on the x it will spawn
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRange, spawnRange), 3);

        //if isspawnclear returns true it has to check anywhere in our spawnPos to make sure something hasnt previously spawned there
        if (isSpawnClear(spawnPos))
        {
            Instantiate(enemiesList[randomIndex], spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.Log("spawn pos is blocked");
        }
    }

    //check for enemies within spawn radius (their colliderS)
    //if no colliders are found return true
    bool isSpawnClear(Vector2 position)
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(position, spawnRadius, enemyLayer);
        //if no collider is found then the position is clear to spawn on
        return hitCollider == null;
    }

    //its going to return how many enemies we have
    int GetEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
