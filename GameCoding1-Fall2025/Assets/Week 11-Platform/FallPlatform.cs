using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public float fallTime = 2f;
    public bool playerOnPlatform = false;
    private bool isFalling;
    private List<Vector3> initalPositions = new List<Vector3>();
    private Collider2D parentCollider;
    // Start is called before the first frame update
    void Start()
    {
        //store the inital positions of each child
       foreach(Transform child in transform)
        {
            
            initalPositions.Add(child.localPosition);
        }

        parentCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //check if player is on platform, fallTime has elapsed, and the coroutine hasnt started
        if(playerOnPlatform &&!isFalling)
        {
            fallTime -=Time.deltaTime;
            if(fallTime < 0)
            {
                StartCoroutine(FallingObject());
                Debug.Log("coroutine started");
                //isfalling is only true when the coroutine has starts
                isFalling = true; //mark it as started
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            fallTime = 2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            isFalling = false;       
            fallTime = 2f;

        }
    }

    private IEnumerator FallingObject()
    {
        //turn off collider on the parent so the player cant stay on it
        parentCollider.enabled = false;

        //grab the rigidbodies of the children, store in an array
        Rigidbody2D[] childRigidbodies = GetComponentsInChildren<Rigidbody2D>();

        //foreach rigidbody in the childRigidbodies array
        foreach(Rigidbody2D rb in childRigidbodies)
        {
            //make it dynamic rigidbody 
            rb.isKinematic = false;
            //turn on the gravity
            rb.gravityScale = 1.0f;
            //wait until next one falls
            yield return new WaitForSeconds(3);
        }
        
        isFalling= false;
    }

    public void ResetPlatform()
    {
        //turn back on the colliders
        parentCollider.enabled = true;
        //stop the coroutine
        StopAllCoroutines();
        //loop through each child and reset its position
        for (int i = 0; i < initalPositions.Count; i++)
        {
            //gets transform of children stores it
            Transform child = transform.GetChild(i);
            //the local pos is the inital position of the objs
            child.localPosition = initalPositions[i];

            //reset gravity on rigidbodies
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                //turn back kinematic so nothing effects it
                rb.isKinematic = true;
                //turn off gravity
                rb.gravityScale = 0f;
                //make sure there is no velocity
                rb.linearVelocity = Vector2.zero;
            }

        }
        //player is not on platform
        playerOnPlatform = false;
        //reset fall time
        fallTime = 2f;
        //make sure is falling is false
        isFalling = false;
    }

}
