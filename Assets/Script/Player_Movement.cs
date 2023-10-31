using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class Player_Movement : MonoBehaviour
{
    public float jumpforce;
    Rigidbody2D rb;
    public bool isJumping;

    public GameObject RespawnPoint;

    public GameObject Enemy;
    private Animator animator;

    private float timer;

    public Slider Slider_Main;
    public Slider Slider_Health;

    public GameObject Finish;

    public SpriteRenderer Player_Image;
    public int health;
    public bool Hurt;
    public float Flashhurt;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player_Image = GetComponent<SpriteRenderer>();
        Finish.SetActive(false);
        Time.timeScale = 1f;
        Hurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        Slider_Main.value= timer;
        Slider_Health.value = health;
        if (timer < 5)
        {
            rb.velocity = new Vector2(directionX * 7f, rb.velocity.y);

            Debug.Log(Flashhurt);

            if (directionX < 0)
            {
                animator.SetBool("Moving", true);
                timer += Time.deltaTime;
            }

            if (directionX > 0)
            {
                animator.SetBool("Moving", true);
                timer += Time.deltaTime;
            }

            if (Input.GetButtonDown("Jump") && isJumping == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }
        if (timer >= 5)
        {
            if(Input.GetKeyDown(KeyCode.P)) 
            { 
                Debug.Log("Je kan weer bewegen");
                timer = 0;
            }
            if (timer > 5)
            {
                timer = 5;
            }
        }
        if(directionX == 0)
        {
            animator.SetBool("Moving", false);
        }
        if (Hurt == false)
        {
            Flashhurt = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag=="Ground")
        {
            Debug.Log("You are touching the ground");
            isJumping = false;
        }

        if (other.transform.tag == "Spikes")
        {
            Debug.Log("You are Dead");
            transform.position = RespawnPoint.transform.position;
            health -= 50;
        }

        if (isJumping == true) 
        {
            if (other.transform.tag == "Enemy_Hitbox")
            {
                Debug.Log("You killed the enemy");
                Enemy.SetActive(false);
            }
        }
        if (other.transform.tag == "Finish_Cube")
        {
            Debug.Log("You Cleared the level");
            Time.timeScale = 0f;
            Finish.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.transform.tag == "Ground")
        {
            Debug.Log("You are in the air");
            isJumping = true;
        }
        Hurt = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (Hurt == false)
            {
                health--;
            }

            Hurt = true;
            if (Hurt == true)
            {
                Flashhurt += Time.deltaTime;

                if (Flashhurt <= 0.5)
                {
                    Player_Image.enabled = true;
                }
                if (Flashhurt > 0.5)
                {
                    Player_Image.enabled = false;
                }
                if (Flashhurt >= 1)
                {
                    Flashhurt = 0;
                }
            }

        }
    }
}
