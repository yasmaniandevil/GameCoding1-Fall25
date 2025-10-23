using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed = 5;

    public int damage = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bullet movement
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)//check to see if enemy has been assigned
            {
                enemy.TakeDamage(damage);
            } 
            Destroy(gameObject);
        }
    }
}
