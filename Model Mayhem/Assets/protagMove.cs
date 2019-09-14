using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protagMove : MonoBehaviour
{
    public mouseFollow myMouse;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public float xSpeed;
    public float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        mousePosition = myMouse.mousePosition;
        /*
        if(transform.position.x > mousePosition.x)
        {
            xSpeed -= .1f;
        }
        else if (transform.position.x < mousePosition.x)
        {
            xSpeed += .1f;
        }
        else if (transform.position.y > mousePosition.y)
        {
            ySpeed -= .1f;
        }
        else if (transform.position.y < mousePosition.y)
        {
            ySpeed += .1f;
        }
        */
        //transform.position = Vector2.Lerp(transform.position, mousePosition*2, moveSpeed);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        //transform.position = new Vector3(transform.position.x + xSpeed, transform.position.y + ySpeed, transform.position.z);
    }
}
