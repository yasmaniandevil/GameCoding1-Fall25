using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrowTwo : MonoBehaviour
{
    private Transform triangleTransform;
    private int direction = 1;
    int moveSpeed = 5;

    float minBoundary = 8;
    float maxBoundary = -8;

    // Start is called before the first frame update
    void Start()
    {
        triangleTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //easy rotate
        //which axis should you rotate on?
        //triangleTransform.Rotate(0, 0, 90);

        triangleTransform.Rotate(Vector3.forward * 20 * Time.deltaTime);

        triangleTransform.localPosition += new Vector3(moveSpeed * direction * Time.deltaTime, 0, 0);

        if(triangleTransform.position.x > minBoundary || triangleTransform.position.x < maxBoundary)
        {
            direction *= -1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            Debug.Log("hit circle");
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.material.color = Color.blue;
            Debug.Log("hit circle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HitMe"))
        {
            Debug.Log("hit obj");
        }
    }
}
