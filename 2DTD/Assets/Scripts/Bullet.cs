using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private GameObject target;
    public float speed;
    // Start is called before the first frame update
    
    public void Initialize(int damage, GameObject target)
    {
        this.damage = damage;
        this.target = target;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            Destroy(gameObject);

        this.transform.position += Vector3.Normalize(target.transform.position - gameObject.transform.position) * speed * Time.deltaTime;
        if(Vector3.Distance(target.transform.position, gameObject.transform.position) <= 0.1)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
