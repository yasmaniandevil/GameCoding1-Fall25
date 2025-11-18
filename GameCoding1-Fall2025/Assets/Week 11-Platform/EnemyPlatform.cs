using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatform : MonoBehaviour
{

    public float attackCoolDown; //time in seconds before the enemy can attack again
    public int damage = 2; //amount of damage enemy deals
    
    //detection vars
    public LayerMask playerLayer;
    public float range; //the distance in which the enemy can detect player
    
    
    private float coolDownTimer = Mathf.Infinity; //timer to track cooldown start that starts at infinity to allow immediate attack
    private BoxCollider2D boxCollider;
    private PlayerHealth playerHealth;
    bool isPlayerDamaged = false;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
        //if we only want them to attack once then we need our damage player function
        //and we say if(playerdamaged) return;
        
        //increase the timer by the time that has passed
        coolDownTimer += Time.deltaTime;

        //check if player is within the detection range and if the enemy can attack
        if(PlayerInSight())
        {
            Debug.Log("Player in range");
            //if cooldowntimer is greater or equal to attackcooldown perform attack
            if(coolDownTimer >= attackCoolDown)
            {
                Debug.Log("attack started cooldown elapsed");
                //reset cooldown timer
                coolDownTimer = 0;
                DamagePlayer();
                
            }
        }
    }

    private bool PlayerInSight()
    {

        if (boxCollider == null)
            return false;

        // Detection box center and size (same as gizmo)
        Vector3 boxCenter = boxCollider.bounds.center;
        Vector2 boxSize = new Vector2(
            boxCollider.bounds.size.x * range,
            boxCollider.bounds.size.y
        );

        Collider2D hit = Physics2D.OverlapBox(boxCenter, boxSize, 0, playerLayer);

        if (hit == null)
        {
            //Debug.Log("OverlapBox: NO hit.");
            return false;
        }

        //Debug.Log("OverlapBox: HIT " + hit.name);
        playerHealth = hit.GetComponent<PlayerHealth>();
        return playerHealth != null;
    }

    private void OnDrawGizmos()
    {

        // 2. Try to grab the collider (works in edit + play).
        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider2D>();

       
        
        Gizmos.color = Color.red;

        Vector3 boxCenter = boxCollider.bounds.center;
        Vector3 boxSize = new Vector3(
            boxCollider.bounds.size.x * range,
            boxCollider.bounds.size.y,
            0.1f
        );

        Gizmos.DrawWireCube(boxCenter, boxSize);
    }

    private void DamagePlayer()
    {
        
        //if script exists
        if(playerHealth != null)
        {
            //get the take damage function pass in an amount
            playerHealth.TakeDamage(damage);
            playerHealth.UpdateText();
            //set to true so it doesnt continue to happen
            isPlayerDamaged = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //change this to checking for the layermask
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("player is out of range");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player is in range");
    }
    
    //if we want them to only attack us once
    /*private void DamagePlayer()
    {
        if (playerHealth == null) return;

        bool didDamage = playerHealth.TakeDamage(damage);
        if (didDamage)
        {
            playerHealth.UpdateText();
            isPlayerDamaged = true;   // only lock out future attacks if damage actually hit
        }
    }*/
}
