using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeek8 : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 5;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

    private void Move(Vector2 direction)
    {
        animator.SetBool("isWalking", true);
        animator.SetFloat("currentInputX", direction.x);
    }
}
