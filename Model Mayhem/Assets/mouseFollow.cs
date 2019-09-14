using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFollow : MonoBehaviour
{
    public GameObject mouseObject;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouseObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseObject.transform.position.z
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, mouseObject.transform.position.z);
    }
}
