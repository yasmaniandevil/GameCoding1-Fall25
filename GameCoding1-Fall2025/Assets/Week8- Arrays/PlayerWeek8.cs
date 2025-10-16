using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeek8 : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 5;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
