using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemevent : MonoBehaviour
{
    Rigidbody rb;
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (directionX*7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(0, 14f, 0);
        }
    }
}
