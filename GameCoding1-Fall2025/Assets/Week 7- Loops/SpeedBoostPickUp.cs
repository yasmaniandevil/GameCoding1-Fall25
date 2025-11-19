using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpeedBoost boostScript = collision.gameObject.GetComponent<SpeedBoost>();

        if (boostScript != null)
        {
            boostScript.ActivateBoost();
            Destroy(gameObject);
        }
    }
}
