﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float force = 4.1f;
    [SerializeField] private float jumpforce = 1f;
    [SerializeField] private float maxSpeed = 0.7f;
    [SerializeField] private float maxJumpSpeed = 0.7f;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform characterLocation;
    public bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
    void FixedUpdate()
    {
        characterLocation = rb.transform;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //control rotation
        if (moveHorizontal < 0)
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        else if(moveHorizontal > 0)
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        Vector2 movement = new Vector2(moveHorizontal, 0);

        //move
        rb.AddForce(movement * force);
        //move check
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }


        if (rb.velocity.y > maxJumpSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector2.up * jumpforce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}