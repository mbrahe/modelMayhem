using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalWalk : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
