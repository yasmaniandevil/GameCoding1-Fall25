using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float forceAmt = 2f;
    private Rigidbody2D rb2d;
    public GameObject playerBulletPrefab;
    public Transform bulletSpawnPoint;
    public int boundary;
    public int health;
    private float shootTimer;
    public float shootInterval = .5f;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("hit key");
            //we can move something by force, by velocity
            //or by transform.position (not physics)
            rb2d.AddForce(Vector3.left * forceAmt);
            Debug.Log("force move");
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector3.right * forceAmt);
        }

        //player is clamped inside of the boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        shootTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && shootTimer >= shootInterval)
        {
            Debug.Log("Hit Space");
            Shoot();
            //reset the timer
            shootTimer = 0;
            Debug.Log("Shoot");
        }
    }

    public void TakeDamage(int damage)
    {
        //subtract damage from health and equal back to health
        health -= damage;
        UpdateHealthText();
        if(health <= 0)
        {
            Debug.Log("ship gives damage");
        }
    }

    void Shoot()
    {
        Instantiate(playerBulletPrefab, bulletSpawnPoint.position, Quaternion.identity);    
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
