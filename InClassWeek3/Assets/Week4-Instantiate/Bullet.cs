using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float bulletSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        MoveBullet(Vector3.right, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveBullet(Vector3 direction, float speed)
    {
        rb2d.linearVelocity = direction * speed;    
    }
}
