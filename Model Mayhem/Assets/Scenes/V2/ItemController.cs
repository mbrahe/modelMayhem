using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float throwSpeed = 10;
    public string itemType;
    Collider2D collider;
    SpriteRenderer sr;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup(Transform actor, float halfHeight)
    {
        transform.parent = actor;
        collider.enabled = false;
        rb.simulated = false;
        Vector3 relPosition = new Vector3(0, halfHeight + sr.size.y, 0);
        transform.localPosition = relPosition;
    }

    public void Throw()
    {
        Vector2 dir = transform.parent.parent.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        transform.parent = null;
        collider.enabled = true;
        rb.simulated = true;
        rb.velocity = dir * throwSpeed;

    }
}
