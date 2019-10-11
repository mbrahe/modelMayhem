using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    ItemController heldItem;
    LinkedList<ItemController> nearby;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        nearby = new LinkedList<ItemController>();
        sr = transform.parent.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pick Up") && nearby.First != null && heldItem == null)
        {
            heldItem = nearby.First.Value;
            heldItem.Pickup(transform, sr.size.y);
            nearby.Remove(nearby.First);

        } else if (Input.GetButtonDown("Pick Up") && heldItem != null)
        {
            heldItem.Throw();
            heldItem = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            ItemController item = collision.gameObject.GetComponent<ItemController>();
            if (!nearby.Contains(item))
            {
                nearby.AddFirst(item);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            ItemController item = collision.gameObject.GetComponent<ItemController>();
            if (nearby.Contains(item))
            {
                nearby.Remove(nearby.Find(item));
            }
        }
    }
}
