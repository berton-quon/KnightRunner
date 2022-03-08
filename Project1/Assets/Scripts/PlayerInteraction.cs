using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera check;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            check.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
