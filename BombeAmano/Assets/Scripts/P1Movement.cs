using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    GameManager gm;

    public Animator anim;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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


        }
        else if (Input.GetKey(KeyCode.S))
        {
            
            SetDirection(Vector2.down);
            anim.SetBool("DownWalk", true);
            anim.SetBool("UpWalk", false);
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", false);


        }
        else if (Input.GetKey(KeyCode.A))
        {
            
            SetDirection(Vector2.left);
            anim.SetBool("DownWalk", false);
            anim.SetBool("UpWalk", false);
            anim.SetBool("LeftWalk", true);
            anim.SetBool("RightWalk", false);


        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            SetDirection(Vector2.right);
            anim.SetBool("DownWalk", false);
            anim.SetBool("UpWalk", false);
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", true);

        }
        else
        {

            anim.SetBool("DownWalk", false);
            anim.SetBool("UpWalk", false);
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", false);
            SetDirection(Vector2.zero);
            

        }

        if(gm.playerLives <= 0)
        {
            gm.isGameOver();
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

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float GetSpeed()
    {
        return speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Explosion") || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gm.playerLives--;
            gameObject.transform.position = new Vector2(-7, 6.3f);
        }
    }
    private void Death()
    {
        enabled = false;
        GetComponent<BombPlacerScript>().enabled = false;

    }
}
