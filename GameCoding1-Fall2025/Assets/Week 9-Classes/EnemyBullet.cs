using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;

    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if enemy bullet hits player
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerShip>().TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Player took damage");
        }
    }
}
