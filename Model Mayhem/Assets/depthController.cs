﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depthController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trans = transform.position;
        trans.z = trans.y + 100f;
        transform.position = trans;
    }
}
