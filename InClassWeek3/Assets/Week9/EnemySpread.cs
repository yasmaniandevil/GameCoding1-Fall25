using UnityEngine;

public class EnemySpread : EnemyBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    //shoot multiple bullets in a spread pattern
    public override void Shoot()
    {
        //the bullets need to come out at an angle so they arent stacked together
        float angleStep = 10;
        for(int i = 0; i <= 3; i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angleStep * i));
        }
    }
}
