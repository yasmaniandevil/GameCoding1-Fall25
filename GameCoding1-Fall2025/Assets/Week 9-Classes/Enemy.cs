using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    //how often we want it to shoot
    public float shootInterval = 4f;
    public GameObject bulletPrefab;
    
    //tracking the time that has passed
    private float shootTimer = 0f;

    //we are using tmp_text because it is a world space 3D text box
    public TMP_Text enemyHealthText;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        UpdateHealthText();
    }  

    // Update is called once per frame
    public virtual void Update()
    {
        //time.delta time is the amount of time that has passed since the last frame
        //value is added to shootTimer every frame so shootTimer increases
        shootTimer += Time.deltaTime;

        //check to see if enough time has passed
        if (shootTimer >= shootInterval)
        {
            Shoot();
            //reset timer for next shot
            shootTimer = 0;
        }
    }

    public virtual void Shoot()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Bullet is not assigned");
        }
    }

    void UpdateHealthText()
    {
        enemyHealthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        //subtract damage from health and update it
        health -= damage;
        UpdateHealthText();
        //if enemy health is 0 destroy enemy
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has no health and is destroyed");
        }
    }
}
