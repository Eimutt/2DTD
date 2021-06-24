using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetingMode
{
    FIRST,
    LAST,
    STRONG
}

public class Tower : MonoBehaviour
{
    public TargetingMode targetingMode;
    public float range;
    public int damage;
    public float firerate;
    public GameObject bulletPrefab;

    private float reloadTimer;
    private bool reloading;

    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reloading)
        {
            if(enemies.Count != 0)
                Shoot();
        } else
        {
            reloadTimer += Time.deltaTime;
            if(reloadTimer >= firerate)
            {
                reloading = false;
                reloadTimer = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if(collision.gameObject.tag == "Enemy")
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

    void Shoot()
    {
        GameObject target = null;

        if(targetingMode == TargetingMode.FIRST)
        {
            target = enemies[0];
        }


        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Initialize(this.damage, target);

        reloading = true;
    }
}
