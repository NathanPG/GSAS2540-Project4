﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int direction;
    public LevelController level;
    Vector3 checkpoint;
    public float movespeed;
    public float jumpforce;
    public Sprite hurt;

    // Start is called before the first frame update
    void Awake()
    {
        checkpoint = new Vector3(-4.59f, -2.39f, -5f);
        direction = 0;
        GetComponent<Animator>().SetBool("isWalking", false);
    }


    public delegate void PlayerHurt();
    public static event PlayerHurt isHurt;
    public delegate void Canvasin();
    public static event Canvasin isIn;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //GetComponent<Animator>().
            GetComponent<SpriteRenderer>().sprite = hurt;
            isHurt?.Invoke();
            //GAME NOT OVER
            if (level.life != 0)
            {
                //RESPAWN
                GetComponent<Animator>().SetBool("isDead", true);
                StartCoroutine("Respawn");
            }
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().SetBool("isDead", false);
        transform.position = checkpoint;
        isIn?.Invoke();
    }


    IEnumerator checklanded()
    {
        yield return new WaitForSeconds(0.1f);
        RaycastHit2D hit2D = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 0.7f, -5), -Vector2.up, 0.1f);
        if (hit2D.collider!= null)
        {
            if (hit2D.collider.gameObject.tag == "Ground")
            {
                GetComponent<Animator>().SetBool("isJumping", false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = transform.position;
        //move left
        GetComponent<Animator>().SetBool("isWalking", false);
        if (Input.GetKey(KeyCode.D))
        {
            if (GetComponent<Animator>().GetBool("isJumping") == false)
            {
                GetComponent<Animator>().SetBool("isWalking", true);
            }
            direction = 0;
            if (pos.x <= 1820f)
            {
                pos.x += movespeed * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                pos.x = 1820f;
            }
        }
        //move right
        else if (Input.GetKey(KeyCode.A))
        {
            if (GetComponent<Animator>().GetBool("isJumping") == false)
            {
                GetComponent<Animator>().SetBool("isWalking", true);
            }
            direction = 1;
            if (pos.x >= -8.6f)
            {
                pos.x -= movespeed * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                pos.x = -8.6f;
            }
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Animator>().GetBool("isJumping") == false)
        {
            GetComponent<Animator>().SetTrigger("Jump");
            GetComponent<Animator>().SetBool("isJumping", true);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }
        if (GetComponent<Animator>().GetBool("isJumping") == true)
        {
            StartCoroutine("checklanded");
        }


        //fall out of world
        if (transform.position.y <= -4.4f)
        {
            GetComponent<SpriteRenderer>().sprite = hurt;
            GetComponent<Animator>().SetBool("isDead", true);
            StartCoroutine("Respawn");
        }

        //turn
        if (direction == 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        //UPDATE CHECKPOINT
        if(pos.x == 1f)
        {
            //SHOW A MSG
        }else if (pos.x == 2f)
        {
            //SHOW A MSG
        }
        else if (pos.x == 3f)
        {
            //SHOW A MSG
        }
    }
}