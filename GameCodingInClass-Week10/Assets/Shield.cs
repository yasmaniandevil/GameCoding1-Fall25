using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldDuration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().ActivateShield(shieldDuration);
            Destroy(gameObject);
        }
    }
}
