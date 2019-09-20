using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protagMove : MonoBehaviour
{
    public mouseFollow myMouse;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public float maxAcceleration = 10f;
    public float xSpeed;
    public float ySpeed;
    public float stunLength = .6f;
    public float energyMax = 1;
    public float energyRegainSpeed = 2;

    bool energyReset;
    bool mouseDown;
    Rigidbody2D rb;
    TextboxController textbox;
    SpriteRenderer sr;
    float stunTimer;
    public float energy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        textbox = GameObject.FindGameObjectWithTag("Textbox").GetComponent<TextboxController>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame

    private void Update()
    {
        mouseDown = Input.GetMouseButton(0);

        if (Input.GetMouseButtonDown(0))
        {
            energyReset = false;
        }
        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        } else if (rb.velocity.x < 0)
        {
            sr.flipX = false;
        }
    }

    void FixedUpdate()
    {
        mousePosition = myMouse.mousePosition;
        /*
        if(transform.position.x > mousePosition.x)
        {
            xSpeed -= .1f;
        }
        else if (transform.position.x < mousePosition.x)
        {
            xSpeed += .1f;
        }
        else if (transform.position.y > mousePosition.y)
        {
            ySpeed -= .1f;
        }
        else if (transform.position.y < mousePosition.y)
        {
            ySpeed += .1f;
        }
        */
        //transform.position = Vector2.Lerp(transform.position, mousePosition*2, moveSpeed);

        //rb.position = Vector2.Lerp(rb.position, mousePosition, moveSpeed);

        //transform.position = new Vector3(transform.position.x + xSpeed, transform.position.y + ySpeed, transform.position.z);

        if (!energyReset && mouseDown && !textbox.inUse && energy >= 0 && stunTimer <= 0)
        {
            Vector2 dir = ((Vector2)mousePosition - rb.position) * moveSpeed;
            dir = dir.normalized * Mathf.Min(dir.magnitude, maxAcceleration);
            rb.AddForce(dir);
            energy -= Time.fixedDeltaTime;
            if (energy <= 0)
            {
                energyReset = true;
            }
        } else
        {
            energy += energyRegainSpeed * Time.fixedDeltaTime;
            if (energy > energyMax)
            {
                energy = energyMax;
            }
        }

        if (stunTimer > 0)
        {
            stunTimer -= Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            stunTimer = stunLength;
        }
    }


}
