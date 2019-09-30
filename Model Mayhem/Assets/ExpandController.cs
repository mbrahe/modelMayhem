using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandController : MonoBehaviour
{
    public int power = 1;
    public float minSize = 2;
    public float maxSize = 4;
    public float speed = 2;

    public Vector3 growthShape = new Vector3(1, 1, 1);

    float t;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1) * minSize;
    }

    private void Update()
    {
        t += Time.deltaTime * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float size = (maxSize - minSize) * Mathf.Abs(Mathf.Pow(Mathf.Sin(t), power));
        transform.localScale = minSize * new Vector3(1, 1, 1) + growthShape * size;
    }
}
