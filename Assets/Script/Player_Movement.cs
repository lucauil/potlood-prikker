using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float jumpforce;
    Rigidbody2D rb;
    public bool isJumping;
    BoxCollider2D Box;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Box = rb.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(directionX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {/*
        if (collision.transform.tag=="Ground")
        {*/
            Debug.Log("You are in the air");
            isJumping = false;
           
        /*}*/
            
    }
    private void OnCollisionExit(Collision collision)
    {
        /*if (collision.transform.tag == "Ground")
        {*/
            Debug.Log("You are touching the ground");
            isJumping = true;
       
        /*}*/
    }
    
}
