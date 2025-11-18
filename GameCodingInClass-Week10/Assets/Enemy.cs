using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackCoolDown; //time in seconds before the enemy can attack again
    public int damage = 2;

    //detectionn variables
    public LayerMask playerLayer;
    public float range; //the distance in which the eneny can attack the player

    private float coolDownTimer = Mathf.Infinity; //timer to track cooldown that starts at infinity to allow immedite attacj
    private BoxCollider2D boxCollider;
    private PlayerHealth playerHealthScript;
    bool isPlayerDamaged = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //increase the timer by the time that has passed
        coolDownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            //Debug.Log("Player in range");
            if(coolDownTimer >= attackCoolDown)
            {
                //Debug.Log("attack cooldown elapsed");
                //reset the timer
                coolDownTimer = 0;
                DamagePlayer();
            }
        }
    }

    private bool PlayerInSight()
    {
        Vector3 boxCenter = boxCollider.bounds.center;
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y);

        Collider2D hit = Physics2D.OverlapBox(boxCenter, boxSize, 0, playerLayer);

        if(hit == null)
        {
            //Debug.Log("No Hit");
            return false;
        }

        //Debug.Log("Hit: " + hit.gameObject.name);
        playerHealthScript = hit.GetComponent<PlayerHealth>();
        return playerHealthScript != null;
    }

    private void OnDrawGizmos()
    {
        if(boxCollider == null) boxCollider = GetComponent<BoxCollider2D>();

        Gizmos.color = Color.red;

        //grabbing the center of the box
        Vector3 boxCenter = boxCollider.bounds.center;
        //multiplying the range on the X bc it needs to be wide, the range
        Vector2 boxSize = new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, 0.1f);

        //draw our box!
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }

    private void DamagePlayer()
    {
        if(playerHealthScript != null)
        {
            playerHealthScript.TakeDamage(2);

        }
    }
}
