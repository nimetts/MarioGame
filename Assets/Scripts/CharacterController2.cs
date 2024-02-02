using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float jumpForce=7.0f;
    private float speed=3.0f;
    private bool jump;
    private bool grounded=true;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float moveDirection;
    private SpriteRenderer _spriteRenderer;
     void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded==true && (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("speed",speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("speed",speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            _animator.SetFloat("speed",0.0f);
        }

        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded",false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {_animator.SetBool("grounded",true);
            grounded = true;
        }
    }
}
