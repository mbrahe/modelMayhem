using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandController : MonoBehaviour
{
    public float minSize = 2;
    public float maxSize = 4;
    public float speed = 2;

    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 0) * minSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = transform.localScale + new Vector3(1, 1, 0) * direction * speed * Time.deltaTime;
        if (transform.localScale.x >= maxSize)
        {
            direction *= -1;
        }
        else if (transform.localScale.x <= minSize)
        {
            direction *= -1;
        }
    }
}
