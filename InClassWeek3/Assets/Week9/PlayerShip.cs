using TMPro;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float forceAmt = 2f;

    public GameObject playerBulletPrfab;
    public Transform bulletSpawnPoint;

    //boundary for our players position, cant go off camera/screen
    public int boundary = 7;
    public int health;
    //keeps track of how much time has passed
    private float shootTimer = 0;
    //how often we shoot (prevents spamming bullets)
    public float shootInterval = .5f;
    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Vector3.left means -1, 0, 0
            rb2d.AddForce(Vector3.left * forceAmt);
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector3.right * forceAmt);
        }

        //player is clamped inside of our boundary
        //can not go past -7 or positive 7
        float clamp = Mathf.Clamp(transform.position.x, -boundary, boundary);
        //when we say transform.position.y or z it means we aren't changing anything and we want to keep it that way
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);

        //time.deltaTime is how much time has passed since we started the game
        //and we are adding it to our shootTimer
        shootTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && shootTimer >= shootInterval)
        {
            Debug.Log("hit space to shoot"); 
            Shoot();
            //reset the shoottimer after we shoot
            shootTimer = 0;
            Debug.Log("Shoot");
        }
    }

    //make it public to call in a different script
    //we are passing in a parameter that is an integer
    public void TakeDamage(int damage)
    {
        //suntract damage from health and equal back to health
        health -= damage;
        //calling it here because when we change health we need to update the text
        UpdateHealthText();
        //if our health is less than or equal to 0
        if(health <= 0)
        {
            Debug.Log("ship died");
        }
    }

    //we call this function when we hit space
    void Shoot()
    {
        Instantiate(playerBulletPrfab, bulletSpawnPoint.position, Quaternion.identity);
    }

    void UpdateHealthText()
    {
        //will display our health and print it as a string
        //to string means it converts it from an int health variable
        healthText.text = "Health: " + health.ToString();
    }
}
