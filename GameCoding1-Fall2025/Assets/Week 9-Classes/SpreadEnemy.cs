using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void Shoot()
    {
        //shoot multiple bullets in a spread pattern
        float angleStep = 10f;
        for(int i = 0; i <= 3; i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angleStep * i));
        }
        
        Debug.Log("spread enemy shoot");
    }
}
