using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavController : MonoBehaviour
{
    public Transform target;
    public float acceleration;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 2);

        /*if (hit.collider != null)
        {
            direction = (Vector2) Vector3.Cross((Vector3) direction, Vector3.forward);
            direction = direction.normalized;
        }*/

        rb.AddForce(direction * acceleration);

    }
}
