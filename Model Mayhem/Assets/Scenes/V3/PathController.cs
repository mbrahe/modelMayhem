using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public Transform[] targets;
    public float targetCloseness = 1f;

    int targetIndex;
    NavController nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavController>();
        nav.target = targets[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(((Vector2) transform.position - (Vector2) nav.target.position).magnitude) < targetCloseness)
        {
            if (targetIndex < targets.Length - 1)
            {
                targetIndex++;
            } else
            {
                targetIndex = 0;
            }

            nav.target = targets[targetIndex];
        }
    }
}
