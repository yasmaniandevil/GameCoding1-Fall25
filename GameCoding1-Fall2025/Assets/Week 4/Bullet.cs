using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
       MoveBullet(Vector3.right, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void MoveBullet(Vector3 direction, float speed)
    {
        //transform.position += direction * speed * Time.deltaTime;
        rb2D.velocity = direction * speed;
    }
}
