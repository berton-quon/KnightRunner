using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Character : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // start position
        //transform.position = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moving", true);
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("moving", true);
            transform.Translate(Vector3.left * Time.deltaTime * 3);
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("moving", true);
            transform.Translate(Vector3.up * Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        // att animation
        if(Input.GetKeyDown(KeyCode.A) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
        }
    }
}