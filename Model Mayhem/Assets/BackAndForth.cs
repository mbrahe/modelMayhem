using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public Vector2 direction;
    public float length;
    public float speed;

    Rigidbody2D rb;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = length;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = length;
            rb.velocity *= -1;
        }
        timer -= Time.deltaTime;
    }
}
