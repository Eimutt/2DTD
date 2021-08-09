using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEnemy : MonoBehaviour
{
    public float speed;
    public int maxHp;
    private int currentHp;
    public float impactThreshold;
    public float damageModifier;

    // Start is called before the first frame update
    private Rigidbody2D m_Rigidbody2D;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;            // Whether or not the player is grounded.
    private Vector3 m_Velocity = Vector3.zero;

    public bool knockedBack;
    private float knockbackStun = 0.4f;
    private float knockbackTimer;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        currentHp = maxHp;
    }

    private void FixedUpdate()
    {
        if (knockedBack)
        {
            knockbackTimer += Time.deltaTime;
            if(knockbackTimer >= knockbackStun)
            {
                knockedBack = false;
                knockbackTimer = 0;
            }
        } else
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;

                    // And then smoothing it out and applying it to the character
                    m_Rigidbody2D.velocity = new Vector2(speed * 10f, m_Rigidbody2D.velocity.y);
                }
            }
        }
        
    }

    
        

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        print("currentHP : " + currentHp + " / " + maxHp);
        if(currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        float impactSpeed = col.relativeVelocity.magnitude;
        if(impactSpeed > impactThreshold)
        {
            TakeDamage((int)impactSpeed);
        }
    }
}
