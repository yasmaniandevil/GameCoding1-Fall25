using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(h * speed, rb.linearVelocity.y);*/
        
        rb.linearVelocity = moveInput * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        
        animator.SetBool("isWalking", true);
        
        if (context.canceled)
        {
            animator.SetBool(("isWalking"), false);
            animator.SetFloat(("LastInputX"), moveInput.x);
            animator.SetFloat(("LastInputY"), moveInput.y);
            
        }
        
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("currentInputX", moveInput.x);
        animator.SetFloat("currentInputY", moveInput.y);
    }
}
