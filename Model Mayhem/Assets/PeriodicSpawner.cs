using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicSpawner : MonoBehaviour
{
    public float period = 6;
    public GameObject obj;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = period;
            Instantiate(obj, transform.position, Quaternion.identity);
        }
    }
}
