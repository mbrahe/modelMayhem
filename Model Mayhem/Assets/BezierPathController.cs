using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierPathController : MonoBehaviour
{
    public float completionTime;
    public Transform[] points;

    Rigidbody2D rb;

    float t;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        t += Time.deltaTime / completionTime;

        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position = (Vector2)(Mathf.Pow(1 - t, 2) * points[0].position + 2 * (1 - t) * t * points[1].position + t * t * points[2].position);
    }
}
