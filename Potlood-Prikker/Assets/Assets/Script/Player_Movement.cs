using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using NUnit.Framework;
using NUnit;


public class Player_Movement : MonoBehaviour
{
    // Movement
    private float jumpforce = 14f;
    Rigidbody2D rb;
    private bool isJumping;
    private int Speed = 5;
    public GameObject RespawnPoint;
    private AudioSource Hurtsound;
    private float FallingThreshold = -0.01f;
    public GameObject TEXT;
    private bool Falling;
    private bool gewonnen;
    public GameObject Enemy;
    private Animator animator;

    private float timer;
    private float lastY;
    public Slider Slider_Main;
    public Slider Slider_Health;

    public GameObject Finish;
    public GameObject Verloren;
    public GameObject Pauze;
    private bool Pauze_ON;

    public SpriteRenderer Player_Image;
    private int health = 100;
    private bool Hurt;
    private float Flashhurt;

    public static bool jumped_On_head;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player_Image = GetComponent<SpriteRenderer>();
        Finish.SetActive(false);
        Time.timeScale = 1f;
        Hurt = false;
        Pauze_ON = false;
        gewonnen =  false;
        Hurtsound = GetComponent<AudioSource>();
        lastY = transform.position.y;
        Hurtsound.Stop();
        TEXT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Slider_Main.value= timer;
        Slider_Health.value = health;
        
        Pauze_Menu();
        Dood();
        Flickering();
        Win_Scherm();
        Cursor.visible = true;
/*      Debug.Log(rb.velocity.y);*/
        float distancePerSecondSinceLastFrame = (rb.velocity.y - lastY) * Time.deltaTime;
        lastY = rb.position.y;  //set for next frame

        float directionX = Input.GetAxis("Horizontal");
        if (timer < 5)
        {
            TEXT.SetActive(false);
            rb.velocity = new Vector2( directionX * 7f, rb.velocity.y);
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
            TEXT.SetActive(true);
            rb.velocity = new Vector2(directionX = 0, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.P))
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

        //Falling
        if(distancePerSecondSinceLastFrame < FallingThreshold)
        {
            Falling = true;

        }
        else
        {
            Falling = false;  
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Ground")
        {
/*            Debug.Log("You are touching the ground");*/
            isJumping = false;
        }

        if (collision.transform.tag == "Spikes")
        {
/*            Debug.Log("You are Dead");*/
            transform.position = RespawnPoint.transform.position;
            health -= 50;
            Hurtsound.Play();
        }

        if (isJumping == true) 
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if(Falling)
                {
                    collision.gameObject.SetActive(false);
                    Debug.Log("You killed the enemy");
                    rb.velocity = new Vector2(rb.velocity.x, 0f);
                    rb.AddForce(Vector2.up * 300f);
                    Hurtsound.Play();
                }
            }
        }
        if (collision.transform.tag == "Finish_Cube")
        {
            gewonnen = true;
        }

        if (collision.transform.tag == "Enemy")
        {
            if(!Falling) 
            {
                Hurt = true;
                if (Hurt == true)
                {
                    health -= 10;
                    Hurtsound.Play();
                }
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Ground")
        {
/*            Debug.Log("You are in the air");*/
            isJumping = true;
        }

    }
    private void Flickering()
    {
        if (Hurt == true)
        {
            Flashhurt += Time.deltaTime*Speed;
            
            if (Flashhurt < 1)
            {
                    Player_Image.enabled = true;
            }

            if (Flashhurt >= 1)
            {
                if(Flashhurt < 2)
                {
                    Player_Image.enabled = false;
                }
            }
            if (Flashhurt >= 2)
            {
                if (Flashhurt < 3)
                {
                    Player_Image.enabled = true;
                }
            }
            if (Flashhurt >= 3)
            {
                if (Flashhurt < 4)
                {
                    Player_Image.enabled = false;
                }
                
            }
            if (Flashhurt >= 4)
            {
                if (Flashhurt < 5)
                {
                    Player_Image.enabled = true;
                }

            }
            if (Flashhurt >= 5)
            {
                if (Flashhurt < 6)
                {
                    Player_Image.enabled = false;
                }

            }
            if (Flashhurt >= 6)
            {
                Player_Image.enabled = true;
                Flashhurt = 0;
                Hurt = false;
                
            }
        }
    }

    public void Enemy_Dood()
    {
     /*   Enemy.SetActive(false);*/
        Debug.Log("You killed the enemy");
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * 300f);
        Hurtsound.Play();
    }
    public void Dood()
    {
        if(health <= 0)
        {
/*            Debug.Log("You died");*/
            Time.timeScale = 0f;
            Verloren.SetActive(true);
        }
    }
    public void Pauze_Menu()
    {
        if(health > 0)
        {
            if (gewonnen == false)
            {
                if (Pauze_ON == false)
                {
                    Time.timeScale = 1f;
                    Pauze.SetActive(false);

                    if (Input.GetKey(KeyCode.Escape))
                    {
                        Pauze_ON = true;
                    }
                }
            }
                if (Pauze_ON == true)
                {
                    Debug.Log("Pauze");
                    Time.timeScale = 0f;
                    Pauze.SetActive(true);


                    if (Input.GetKey(KeyCode.Escape))
                    {
                        Pauze_ON = false;
                    }
                }
        }
    }
    public void Win_Scherm()
    {
        if (gewonnen == true)
        {
            Finish.SetActive(true);
            Debug.Log("You Won");
            Time.timeScale = 0f;
        }
    }
}
