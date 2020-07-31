using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float forse;
    Rigidbody2D playerRb;
    SpriteRenderer playerSprite;
    public Animator anim { get; set; }
    public bool canJump { get; set; }   

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.y < Camera.main.ViewportToWorldPoint(Vector3.zero).y)
        {
            Destroy(this.gameObject);
        }
    }

    public void Jump()
    {
        if (canJump)
        {
            anim.SetTrigger("Jump");
            //anim.Play("Jump");
            playerRb.AddForce(Vector2.up * forse, ForceMode2D.Impulse);
        }
    }

    public void Move(float temp)
    {
        if (canJump)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
        playerRb.AddForce(Vector2.right * speed * temp, ForceMode2D.Impulse);
    }

    public bool Flip
    {
        get
        {
            return playerSprite.flipX;
        }
        set
        {
            playerSprite.flipX = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            canJump = true;
        }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision != null)
    //    {
    //        canJump = false;
    //    }
    //}

}
