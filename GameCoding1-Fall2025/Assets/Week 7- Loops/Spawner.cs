using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    //variables for simple loop in start
    public GameObject pickupPrefab;
    //how many coins
    public int numberToSpawn;
    //distance btwn each coin
    public float spacing = 1.5f;
    //where the row begins
    public Vector2 startPosition = new Vector2(-4, 2);
    
    //variables for grid spawner
    //more complex nested loop
    [FormerlySerializedAs("gridPrefab")] public GameObject obstaclePrefab;
    public int rows = 4;
    public int columns = 8;
    public float cellSize = 1.5f;
    public Vector2 startOrigin = new Vector2(-5, 2);
    //define a safe gap (rectagle) 
    //any cell size inside this rectangle will not spawn an obstacle
    public int safeRowFrom = 1;
    public int safeRowTo = 2;
    public int safeColFrom = 3;
    public int safeColTo = 4;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //move this to a function
        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector2 pos = new Vector2(startPosition.x + i * spacing, startPosition.y);
            Instantiate(pickupPrefab, pos, Quaternion.identity);
        }
        
        ObstacleGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ObstacleGrid()
    {
        //outer loop goes through each row
        for (int r = 0; r < rows; r++)
        {
            //inner loop goes through each column inside that row
            for (int c = 0; c < columns; c++)
            {
                //we will figure out if this specific cell is inside the safe gap
                //start by assuming it is not insie the safe gap
                bool isInsideTheGap = false;
                
                //first check if the row is inside the safe row range
                if (r >= safeRowFrom && r <= safeRowTo)
                {
                    //if the row matches now check if the column is inside the safe column range
                    if (c >= safeColFrom && c <= safeColTo)
                    {
                        //if both row and column are in range the cell is inside the gap
                        isInsideTheGap = true;
                    }
                }
                
                //only spawn an onstacle if we are not inside the safe gap
                if (!isInsideTheGap)
                {
                    //calculate the world position of this cell
                    float xPos = startOrigin.x + (c * cellSize);
                    float yPos = startOrigin.y + (r * cellSize);
                    Vector2 spawnPos = new Vector2(xPos, yPos);
                    
                    //then create the obstacle
                    Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
                }
                
            }
        }
    }
}
