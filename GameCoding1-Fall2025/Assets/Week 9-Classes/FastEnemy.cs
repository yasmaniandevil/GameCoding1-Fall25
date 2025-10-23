using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    // Start is called before the first frame update
    public override void  Start()
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
        shootInterval = 2f;
        base.Shoot();
        Debug.Log("Fast Enemy is Shooting");
    }
}
