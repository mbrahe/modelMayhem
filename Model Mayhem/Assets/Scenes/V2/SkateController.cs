using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateController : MonoBehaviour
{
    public float acceleration;
    public float friction;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    Vector2 inputDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (inputDirection.magnitude >= .1f)
        {
            animator.Play("walk");
        } else
        {
            animator.Play("stand");
        }
        if (rb.velocity.x > .1f)
        {
            sr.flipX = true;
        } else if (rb.velocity.x < -.1f)
        {
            sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(acceleration * inputDirection.normalized, ForceMode2D.Impulse);
        rb.AddForce(-friction * rb.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //transform.FindChild("Particle System").gameObject.GetComponent<ParticleSystem>().Play();
        transform.Find("Particle System").gameObject.GetComponent<ParticleSystem>().Play();
    }
}
