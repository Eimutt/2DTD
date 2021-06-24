using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float maxHp;

    public float currentHp;

    private Vector3 targetDirection;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetDirection * speed * Time.deltaTime;
    }

    public void SetTarget(GameObject nextTarget)
    {
        targetDirection = Vector3.Normalize(nextTarget.transform.position - gameObject.transform.position);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Send Die Event(give out gold + update game state and such)
        Destroy(gameObject);
    }
}
