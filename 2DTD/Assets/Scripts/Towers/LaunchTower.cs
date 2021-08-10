using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTower : Tower
{
    public float strength;

    public Vector2 Angle;

    public override void Shoot()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(Angle.normalized * strength);
            enemy.GetComponent<PhysicsEnemy>().knockedBack = true;
        }
        reloading = true;
    }
}
