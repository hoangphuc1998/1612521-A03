using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XProcessor : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 0.01f;
    public float jumpSpeed = 200.0f;
    Animator anim;
    int runHash = Animator.StringToHash("Run");
    SpriteRenderer render;
    public int maxJump = 2;
    bool isOnGround = true;
    bool jumpLock = false;
    // Start is called before the first frame update

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (isOnGround)
            {
                anim.SetBool(Animator.StringToHash("Running"), true);
            }
            render.flipX = false;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (isOnGround)
            {
                anim.SetBool(Animator.StringToHash("Running"), true);
            }
            render.flipX = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool(Animator.StringToHash("Running"), false);
        }

        if (Input.GetKeyDown(KeyCode.X) && maxJump!=0 && !jumpLock)
        {
            anim.SetTrigger(Animator.StringToHash("Jump"));

            if (maxJump == 1)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
            }
            isOnGround = false;
            rigid.AddForce(new Vector2(0, jumpSpeed));
            maxJump -= 1;
            jumpLock = true;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            jumpLock = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (!isOnGround)
            {
                anim.SetTrigger(Animator.StringToHash("Land"));
            }
            isOnGround = true;
            maxJump = 2;

            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }
}
