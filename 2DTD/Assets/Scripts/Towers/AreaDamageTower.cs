using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamageTower : Tower
{

    public override void Shoot()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<PhysicsEnemy>().TakeDamage(damage);
        }
        reloading = true;
    }
}
