using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private CharacterController2D controller;

    public float horizontalMove = 0f;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        
        jumping = Input.GetKey(KeyCode.Space);


    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove, jumping);
        
    }
}
