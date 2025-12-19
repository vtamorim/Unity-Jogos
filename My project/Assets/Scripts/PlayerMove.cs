using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    public float speed; public bool isJumping; public bool isDoubleJump; public float JumpForce; private Rigidbody2D rig;private float baseSpeed;
    private Animator anim;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        baseSpeed = speed;
    }

    void Update()
    {
        Move();
        Jump();
    }



    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += direction * speed * Time.deltaTime;


        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("Walk", true);
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isDoubleJump = true;
                anim.SetBool("Jump", true);
            }
            else
            {
                if (isDoubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    isDoubleJump = false;
                }
            }
        }
    }


    public void ResetSpeed()
    {
        speed = baseSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            isDoubleJump = false;
            anim.SetBool("Jump", false);
           
        }

        if (collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);

        }
    }
    void OnCollisionExit2D(Collision2D collision) { if (collision.gameObject.layer == 8) { isJumping = true; } }
}