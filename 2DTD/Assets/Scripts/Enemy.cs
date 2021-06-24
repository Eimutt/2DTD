using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float hp;
    public Vector3 targetDirection;
    // Start is called before the first frame update
    void Start()
    {
        //targetDirection = Vector3.left;
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
}
