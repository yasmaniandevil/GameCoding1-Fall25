using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPlatform : MonoBehaviour
{

    public float bulletDamage = 10f;
    public float bulletSpeed = 5f;
    private float direction = 1f;


    public void SetDirection(float newDirection)
    {
        direction = newDirection;
    }

    // Update is called once per frame
    void Update()
    {
        //bullet movement
        transform.Translate(Vector2.right * direction * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        //if bullet hits anything on the enemy layer
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Found enemy");
            Destroy(collision.gameObject);
        }
    }
}
