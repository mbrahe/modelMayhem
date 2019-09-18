using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float yMargin = .1f;
    public float xMargin = .2f;
    public float correctionCoefficient = .5f;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetVector = Vector2.zero;
        Vector2 position = Camera.main.WorldToViewportPoint(target.position);

        Debug.Log(position);

        if (position.x <= xMargin)
        {
            targetVector.x = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
        }  else if (position.x >= (1 - xMargin))
        {
            targetVector.x = Camera.main.ViewportToWorldPoint(Vector2.right).x;
        }

        if (position.y <= yMargin)
        {
            targetVector.y = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
        }
        else if (position.y >= (1 - yMargin))
        {
            targetVector.y = Camera.main.ViewportToWorldPoint(Vector2.up).y;
        }

        Vector3 targetVector3D = (Vector3)targetVector;
        targetVector3D.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetVector3D, correctionCoefficient * Time.deltaTime);
    }
}
