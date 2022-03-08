using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_Berton : MonoBehaviour
{

    public Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // start position
        //transform.position = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public float speed = 5f;
    public float horizontal;
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
    }
}