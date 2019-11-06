using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float throwSpeed = 10;
    public string itemType;
    public float ignoreSpeed = 5;
    Collider2D collider;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Collider2D thrower;

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
        if (collider.enabled)
        {
            if (rb.velocity.magnitude <= ignoreSpeed)
            {
                //Physics2D.IgnoreCollision(collider, thrower, false);
                if (thrower != null)
                {
                    //Physics2D.IgnoreCollision(thrower, collider, false);
                    Physics2D.IgnoreLayerCollision(10, 8, false);
                }
            }

            if (rb.velocity.magnitude == 0)
            {
                rb.isKinematic = true;
            }
        }
    }

    public void Pickup(Transform actor, float halfHeight)
    {
        transform.parent = actor;
        thrower = actor.gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
        rb.simulated = false;
        Vector3 relPosition = new Vector3(0, halfHeight + sr.size.y, 0);
        transform.localPosition = relPosition;
    }

    public void Throw()
    {
        Vector2 dir = transform.parent.parent.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        Vector2 pos = transform.parent.parent.position;// + thrower.offset.y * Vector3.up;
        transform.parent = null;
        collider.enabled = true;
        rb.isKinematic = false;
        rb.simulated = true;
        transform.position = pos;
        rb.velocity = dir * throwSpeed;
        //Physics2D.IgnoreCollision(thrower, collider, true);
        Physics2D.IgnoreLayerCollision(10, 8, true);
    }
}
