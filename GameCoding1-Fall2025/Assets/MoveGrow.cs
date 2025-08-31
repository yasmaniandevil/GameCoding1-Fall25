using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrow : MonoBehaviour
{

    Transform square;

    int direction = 1;

    float moveSpeed = 3;

    float minBoundary = 8;
    float maxBoundary = -8;

    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //move
        square.position += new Vector3(moveSpeed * direction * Time.deltaTime, 0, 0);

        if(square.position.x > minBoundary || square.position.x < maxBoundary)
        {
            Debug.Log("passed it");
            direction *= -1;

            if(square.localScale.y > 3)
            {

            }
        }

        //rotate
        square.Rotate(0, 0, 20);

        square.localScale = new Vector3(3, 3, 3);
    }
}
