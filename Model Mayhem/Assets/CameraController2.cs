using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{

    public GameObject player;
    Rigidbody2D rb;
    public float factor, factor2;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 target = player.transform.position + (Vector3)rb.velocity * factor2;
        Vector3 dist = -(transform.position - target);
        transform.position += Vector3.Scale(dist, new Vector3(factor, factor, 0));


    }
}
