using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_con : MonoBehaviour
{
    private Animator anim;
    private bool isjump = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
            Vector3 force = new Vector3(0, 0, 21);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force); 
            }
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("back_walk", true);
            Vector3 force = new Vector3(0, 0, -15);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force); 
            }
        }
        else
        {
            anim.SetBool("back_walk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("right_waik", true);
            Vector3 force = new Vector3(17, 0, 0);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force);
            }
        }
        else
        {
            anim.SetBool("right_waik", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("left_walk", true);
            Vector3 force = new Vector3(-17, 0, 0);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force); 
            }
        }
        else
        {
            anim.SetBool("left_walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))//&& isjump == false)
        {
            anim.SetTrigger("jumpp");
            rb.velocity = new Vector3(0, 5, 0);
            isjump = true;
        }
        else
        {
            anim.SetBool("jump", false);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isjump = false;
        }
    }
}
