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

    public Vector3 scaleUpDown = new Vector3 (3, 3, 3);

    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<Transform>();

        //this is how just to change scale
        square.localScale = new Vector3(3, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //move
        square.position += new Vector3(moveSpeed * direction * Time.deltaTime, 0, 0);

        square.localScale += scaleUpDown;

        if(square.position.x < minBoundary || square.position.x > maxBoundary)
        {
            Debug.Log("passed it");
            direction *= -1;

            //if square scale larger or equal to 3
            //or less than or equal to -3
            if(square.localScale.y >= 3 || square.localScale.y <= -3)
            {
                Debug.Log("shrink");
                //square.localScale = transform.localScale * -1;
                //scaleUpDown = -scaleUpDown;
                Debug.Log("checking the shrink");
            }
        }

        //rotate simple
        //square.Rotate(0, 0, 20);
        //rotate by speed
        square.Rotate(Vector3.forward * 20 * Time.deltaTime);

        
    }
}
