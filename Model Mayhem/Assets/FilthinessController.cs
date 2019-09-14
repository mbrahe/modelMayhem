using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilthinessController : MonoBehaviour
{
    public float filthSpeed = .6f;
    bool inShade;

    StoryController story;
    // Start is called before the first frame update
    void Start()
    {
        story = GameObject.FindGameObjectWithTag("Story").GetComponent<StoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inShade)
        {
            story.filthiness += filthSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shade")
        {
            inShade = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Shade")
        {
            inShade = false;
        }
    }
}
