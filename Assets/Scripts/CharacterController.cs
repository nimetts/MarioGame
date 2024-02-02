using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    public float speed= 1.0f;
    private Rigidbody2D r2D;
    private Animator animator;
    private Vector3 charPos;
   [SerializeField] private GameObject camera;
   private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();// caching sprite renderer flipleme yöntemi
        r2D = GetComponent<Rigidbody2D>();// caching r2d 1. yöntemA
        animator = GetComponent<Animator>();// caching component
        charPos = transform.position;
    }

    private void FixedUpdate()
    {
       // r2D.velocity = new Vector2(speed, 0f);//fizik hesaplamaları fixedUpdate başına yapılır
    }


    private void Update() //frame başına yapılır
    {
        /* if (Input.GetKey(KeyCode.Space))//1. yöntemB
         {
             speed = 1.0f;
             //Debug.Log("Hız 1.0 f");
         }
         else
         {
             speed = 0.0f;
            // Debug.Log("Hız 0.0 f");
         }*/

        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y); //pozisyon hesaplaması 2. yöntemB
        transform.position = charPos; //hesapladığım pozisyon karakterime işlensin
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            animator.SetFloat("speed", 0.0f);
        }
        else
        {
           animator.SetFloat("speed",1.0f);//space tuşu sonrası değişen hız animasyona etki etti

        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void LateUpdate()
    {
        //camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);//2. yöntemA
    }


}