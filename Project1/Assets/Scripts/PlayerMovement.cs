using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _horizontal;
    public float speed = 10f;
    public float jump = 20f;
    public float acceleration = 10f;
    public float decceleration = 10f;
    public float velPower = 0.9f;
    public float frictionAmount = 1f;
    public float gravityScale = 2f;
    public float fallGravityMultiplier = 1f;
    public LayerMask ground;
    bool groundcheck = true;
    Rigidbody2D rb;

    private float coyoteTime = 0.018f;
    private float groundtime;
    private float jumptime;
    public float jumpBuffer = 0.018f;
    float jumpcutNum = 0.5f;
    bool jumpCheck = true;


    public Camera playerCamera;
    Animator animator;

    void Start()
    {
        // start position
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        Friction();
        Movement();

        Animation();


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumptime = jumpBuffer;
            groundcheck = false;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            JumpCut();
        }
        Gravity();

        groundtime -= Time.deltaTime;
        jumptime -= Time.deltaTime;

        if (Physics2D.OverlapBox(rb.transform.position, new Vector2(1, 1), 0, ground) && rb.velocity.y < 1f)
        {
            groundcheck = true;
            groundtime = coyoteTime;
        }

        if(jumpCheck && rb.velocity.y<0)
        {
            jumpCheck = false;
            
        }
        if (jumptime > 0)
        {
            if (groundtime > 0)
            {
                jumpCheck = true;
                Jump();
            }
        }
    }

    public void JumpCut()
    {
        if (rb.velocity.y > 0 && jumpCheck)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * (1 - jumpcutNum), ForceMode2D.Impulse);
        }
        jumptime = 0;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "camera")
        {
            speed = 0;
        }
    }
    public void Animation()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moving", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    public void Movement()
    {

        float targetSpeed = _horizontal * speed;
        float speedDiff = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDiff) * accelRate, velPower) * Mathf.Sign(speedDiff);
        rb.AddForce(movement * Vector2.right);
    }

    public void Friction()
    {

        if (Mathf.Abs(_horizontal) < 0.01f)
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb.velocity.x);
             rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
            Debug.Log(amount );
        }
    }
    private void Jump()
    {
        jumptime = 0;
        groundtime = 0;
        rb.velocity = new Vector2(rb.velocity.x, jump);
    }

    private void Gravity()
    {
        if(rb.velocity.y <0)
        {
            rb.gravityScale = gravityScale * fallGravityMultiplier;
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
    }
}
