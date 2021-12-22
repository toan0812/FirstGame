using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // tọa biến di chuyển 
    private Rigidbody2D Playerrb;
    [SerializeField] private float MoveSpeed = 10f;
    [SerializeField] private float JumpForce = 15f;
    private float Move;

    // tạo biến kiểm tra hướng mặt của player 
    bool FacingRight = true;

    // tạo biến kiểm tra khi nhảy 
    bool isGrounded;
    private int extraJump;
    [SerializeField] private int extraJumpvalue;
    [SerializeField] private LayerMask WhatIsGounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;

    // khai báo biến anim trong animator
    private Animator Anim;
    private enum MovementState {idle, Running, Jump, Falling }
    private MovementState state;
    //
    

    void Start()
    {
        extraJump = extraJumpvalue;
        Playerrb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
 

    }

 
    void FixedUpdate()
    {
        // kiểm tra điểm va chạm của player  
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGounded);

        // di chuyển player

        Move = Input.GetAxisRaw("Horizontal");
        Playerrb.velocity = new Vector2(MoveSpeed * Move, Playerrb.velocity.y);

        // kiểm tra hướng mặt của player và flip() lại 
        if (FacingRight == false && Move > 0)    
        {
            Flip();
        }
        else if(FacingRight == true && Move < 0)
        {
            Flip();
        }

    }
    private void Update()
    {
        //hàm double jump
        if (isGrounded == true)
        {
            extraJump = extraJumpvalue;
        }
        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            Playerrb.velocity = new Vector2(Playerrb.velocity.x, JumpForce);
            extraJump--;
        }
        else if (Input.GetButtonDown("Jump") && extraJump == 0 && isGrounded == true)
        {
            Playerrb.velocity = new Vector2(Playerrb.velocity.x, JumpForce);
        }
        UpdateAnimationUpdate();
    }
    // hàm flip() player
      void Flip()
    {
        FacingRight =! FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
     
     private void UpdateAnimationUpdate()
    {
        
        // Hàm  Running
        if (Move > 0f)
        {
            state = MovementState.Running;
        }
        else if (Move < 0f)
        {
            state = MovementState.Running;
        }
        else if (Move == 0f)
        {
            state = MovementState.idle;
        }

        // Hàm  Jump
        if (Playerrb.velocity.y > 0.1f)
        {
            state = MovementState.Jump;
        }
        else if (Playerrb.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }
        Anim.SetInteger("State", (int)state);
        
    }
  
}

