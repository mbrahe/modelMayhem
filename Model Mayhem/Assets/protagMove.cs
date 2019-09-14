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

    bool mouseDown;
    Rigidbody2D rb;
    TextboxController textbox;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        textbox = GameObject.FindGameObjectWithTag("Textbox").GetComponent<TextboxController>();
    }
    // Update is called once per frame

    private void Update()
    {
        mouseDown = Input.GetMouseButton(0);
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

        if (mouseDown && !textbox.inUse)
        {
            Vector2 dir = ((Vector2)mousePosition - rb.position) * moveSpeed;
            dir = dir.normalized * Mathf.Min(dir.magnitude, maxAcceleration);
            rb.AddForce(dir);
        }
    }
}
