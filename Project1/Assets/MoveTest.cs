using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    float _horizontal;
    float _vertical;
    public float speed = 10f;
    public float jump = 20f;
    public float acceleration = 10f;
    public float decceleration = 10f;
    public float velPower = 0.9f;
    Rigidbody2D rb;

    void Start()
    {
        // start position
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        float targetSpeed = _horizontal * speed;
        float speedDiff = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDiff) * accelRate, velPower) * Mathf.Sign(speedDiff);
        rb.AddForce(movement * Vector2.right);
    }

}
