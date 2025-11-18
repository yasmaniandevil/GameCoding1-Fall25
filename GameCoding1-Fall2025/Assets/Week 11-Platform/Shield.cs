using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldDuration = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().ActivateShield(shieldDuration);
            Destroy(gameObject);
        }
    }
}
