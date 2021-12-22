using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_attack : MonoBehaviour
{
    //khai bao bien
    private Rigidbody2D rb;
    //[SerializeField] private float PushBackForce;
    private Animator Anim;
    private bool FacingLeft= true;
    private float nextFlip = 0f;
    private float FacingTime = 5f;
    //public GameObject Enemies;
    [SerializeField] private float Speed;
    bool canflip = true;
    //wall check
    [SerializeField] private LayerMask WhatIsGounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    bool isGrounded = true;
    int i;


    private enum MovementState { Rino_idle, Rino_Run,Rino_hitwall,Rino_hit }
    private MovementState state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //wall check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGounded);
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + FacingTime;
            Flip();
        }
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (FacingLeft == false && collision.transform.position.x < transform.position.x)
            {
                Flip();
                

            }
            else if(FacingLeft && collision.transform.position.x > transform.position.x)
            {
                Flip();
                

            } 
            canflip = false;
        }
        
    }
    void Enemy_speedRun()
    {
        if (FacingLeft == false)
        {
            rb.AddForce(new Vector2(1, 0) * Speed);
        }
        else
        {
            rb.AddForce(new Vector2(-1, 0) * Speed);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Enemy_speedRun();
            state = MovementState.Rino_Run;
        }
        Anim.SetInteger("Rino_state", (int)state);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isGrounded == true)
        {

            rb.velocity = new Vector2(0, 0);
            canflip= true;
            state = MovementState.Rino_hitwall;
            
        }
        if (isGrounded == false)
        {
            state = MovementState.Rino_Run;
        }
        
        if(collision.gameObject.CompareTag("Player"))
        {
            state = MovementState.Rino_hit;
        }
        Anim.SetInteger("Rino_state", (int)state);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canflip = true;
            rb.velocity = new Vector2(0, 0);
            state = MovementState.Rino_idle;
        }
        Anim.SetInteger("Rino_state", (int)state);
    }
    

    void Flip()
    {
        if(!canflip)
        {
            return;
        }
        FacingLeft = !FacingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

}
