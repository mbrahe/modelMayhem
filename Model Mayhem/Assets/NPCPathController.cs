using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPathController : MonoBehaviour
{
    public float walkSpeed = 1f;
    public float standTime = .5f;
    public int firstPoint = 1;
    public Transform[] points;
    public float lerpSpeed = .5f;


    Rigidbody2D rb;
    float waitTimer;
    bool waiting;
    float lerpPosition;
    int currentPoint;
    int nextPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = 0;
        nextPoint = 1;
    }

    void NextPoint()
    {
        waiting = false;
        lerpPosition = 0;
        currentPoint = nextPoint;
        nextPoint++;
        if (nextPoint == points.Length)
        {
            nextPoint = 0;
        }
    }

    private void Update()
    {
        Debug.Log(waitTimer);
        if (waiting && waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
        }
        else if (waiting)
        {
            NextPoint();
        }

        if (lerpPosition < 1 && !waiting)
        {
            float distance = (rb.position - (Vector2)points[currentPoint].position).magnitude;
            float fullJourney = (points[nextPoint].position - points[currentPoint].position).magnitude;
            lerpPosition += lerpSpeed * Mathf.Pow(Mathf.Cos(distance / fullJourney), 2) * Time.deltaTime;
        } else if (!waiting)
        {
            waitTimer = standTime;
            waiting = true;
        }
    }

    private void FixedUpdate()
    {
        rb.position = Vector2.Lerp(points[currentPoint].position, points[nextPoint].position, lerpPosition);
    }
}
