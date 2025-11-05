using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystaem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    private Vector2 moveInput;
    
    public GameObject animationObject;
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = animationObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);
        moveInput = context.ReadValue<Vector2>();

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        
        animator.SetFloat("currentInputX", moveInput.x);
        animator.SetFloat("currentInputY", moveInput.y);
    }
}
