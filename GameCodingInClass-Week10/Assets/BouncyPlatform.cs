using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public float bounceForce = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
