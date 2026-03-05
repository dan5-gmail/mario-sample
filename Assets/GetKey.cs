using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class GetKey : MonoBehaviour
{
    public float speed = 2;

    float vx = 0;
    bool leftFlag = false;
    bool isGround = false;
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 1;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void Update()
    {
        vx = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            vx = speed;
            leftFlag = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            vx = -speed;
            leftFlag = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, 5);
            isGround = false;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(vx, rbody.linearVelocity.y);
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
