using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public SpriteRenderer UpSprite;
    public SpriteRenderer DownSprite;
    public SpriteRenderer LeftSprite;
    public SpriteRenderer RightSprite;

    public Animator anim;

    private SpriteRenderer playerSprite;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            SetDirection(Vector2.up);
            anim.SetBool("DownWalk", false);
            anim.SetBool("UpWalk", true);
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", false);
            playerSprite.sprite = UpSprite.sprite;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetDirection(Vector2.down);
            anim.SetBool("DownWalk", true);
            anim.SetBool("UpWalk", false);
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", false);
            playerSprite.sprite = DownSprite.sprite;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            
            SetDirection(Vector2.left);
            anim.SetBool("DownWalk", false);
            anim.SetBool("UpWalk", false);
            anim.SetBool("LeftWalk", true);
            anim.SetBool("RightWalk", false);
            playerSprite.sprite = LeftSprite.sprite;

        }
        else if (Input.GetKey(KeyCode.D))
        {

            SetDirection(Vector2.right);
            anim.SetBool("DownWalk", false);
            anim.SetBool("UpWalk", false);
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", true);
            playerSprite.sprite = RightSprite.sprite;
        }
        else
        {
            SetDirection(Vector2.zero);

        }

    }

    private void FixedUpdate()
    {

        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;

    }

}
