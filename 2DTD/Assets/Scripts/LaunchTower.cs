using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTower : MonoBehaviour
{
    public float fireRate;
    public float strength;

    public float reloadTimer;
    public bool reloading;

    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!reloading)
        {
            if (enemies.Count != 0)
                Shoot();
        }
        else
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= fireRate)
            {
                reloading = false;
                reloadTimer = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }
    }

    public void Shoot()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * strength);
            enemy.GetComponent<PhysicsEnemy>().knockedBack = true;
        }
        reloading = true;
    }
}
