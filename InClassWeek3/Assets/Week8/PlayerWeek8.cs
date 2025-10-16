using UnityEngine;

public class PlayerWeek8 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb2d.linearVelocity = new Vector2 (horizontalInput * speed, verticalInput * speed);
    }
}
