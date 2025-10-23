using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health = 100;
    public int shootInterval = 4;
    public GameObject bulletPrefab;
    private float shootTimer = 0;

    //we are using tmp_text bc it is a world space 3D text box that we are attaching to our enemy
    public TMP_Text enemyHealthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        UpdateHealthText();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        shootTimer += Time.deltaTime;

        //check to see if enough time has passed
        if(shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    //virtual so we can override in our subclasses
    public virtual void Shoot()
    {
        //if we have something in the inspector
        if(bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("bullet prefab has not been assigned");
        }
    }

    void UpdateHealthText()
    {
        enemyHealthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthText();
        //if enemy health is below or equal to zero destroy enemy
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy health is 0 and enemy has been destroyed");
        }
    }
}
