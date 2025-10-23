using UnityEngine;

public class EnemyFast : EnemyBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        //it is calling the start in the enemy base class
        base.Start();
    }  

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Shoot()
    {
        shootInterval = 2;
        base.Shoot();
        Debug.Log("fast enemy is shooting");
    }
}
