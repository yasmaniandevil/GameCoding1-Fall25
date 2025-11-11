using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed = 3f;
    public int damage = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bullet movement
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

        //if our bullet is off screen, destroy it
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //we make a variable out of our enemy base script
            //we are grabbing it off of what we are colliding with
            EnemyBase enemy = collision.GetComponent<EnemyBase>();
            if(enemy != null) //check to see if enemy has been assigned
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }


}
