using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{
    public float jumpforce;
    Rigidbody2D rb;
    public bool isJumping;
    BoxCollider2D Box;
    public GameObject Enemy;



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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag=="Ground")
        {
            Debug.Log("You are touching the ground");
            isJumping = false;
        }

        if(isJumping == true) 
        {
            if (other.transform.tag == "Enemy")
            {
                Debug.Log("You killed the enemy");
                Enemy.SetActive(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Ground")
        {
            Debug.Log("You are in the air");
            isJumping = true;
        }
    }
}
