using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float yMargin = .1f;
    public float xMargin = .2f;
    public float acceleration = 1f;

    Transform target;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetVector = Vector2.zero;
        Vector2 position = Camera.main.WorldToViewportPoint(target.position);

        if (position.x <= xMargin || position.x >= (1 - xMargin))
        {
            //targetVector.x = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
            //targetVector.x = target.position.x;
            rb.AddForce(acceleration * Vector2.right * (target.position.x - transform.position.x));
            
        }

        if (position.y <= yMargin || position.y >= (1 - yMargin))
        {
            //targetVector.y = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
            //targetVector.y = target.position.y;
            rb.AddForce(acceleration * Vector2.up * (target.position.y - transform.position.y));
        }
    }
}
