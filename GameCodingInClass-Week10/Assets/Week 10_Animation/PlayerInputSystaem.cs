using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystaem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    private Vector2 moveInput;
    
    //object that has the animator on it (the child in this case)
    public GameObject animationObject;
    //mde a var to store the animator from the obj above 
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //we have our animation on the child object so first we have to say that speicific object, I want its animator
        //otherwise unity would be trying to grab the animator from the parent which has no animator component (just physics)
        animator = animationObject.GetComponent<Animator>();
    }

    // fixedupdate is not frame rate dependent, it runs in consistent intervals instead
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }

    //unity calls this function automatically whenever the Move action changes (for example, when you press, hold, or release movement keys)
    //context parameter gives info about whether the action was started, performed, or cancelled
    //what the current value of the input is (like (1, 0) for D/Right
    
    public void Move(InputAction.CallbackContext context)
    {
        //start animation when any input is detected
        animator.SetBool("isWalking", true);

        //if player stops moving (input cancelled)
        if (context.canceled)
        {
            //stop walking
            animator.SetBool("isWalking", false);
            //store last X direction
            animator.SetFloat("LastInputX", moveInput.x);
            //store last y direction
            animator.SetFloat("LastInputY", moveInput.y);
        }
        
        //get the current movement input (ex: WASD)
        //context.readvalue gives the current keyboard direction
        //store in moveInput
        moveInput = context.ReadValue<Vector2>();
        
        //send it to the animator to control direction of animation
        animator.SetFloat("currentInputX", moveInput.x);
        animator.SetFloat("currentInputY", moveInput.y);
    }
    
    //invoke unity events (in the inspector) means unity will call the function when asked for
    //when we press WASD "move" function is called
    
}
