using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretteController : MonoBehaviour
{
    StoryController story;
    // Start is called before the first frame update
    void Start()
    {
        story = GameObject.FindGameObjectWithTag("Story").GetComponent<StoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (story != null)
            {
                if (!story.hasCigarette)
                {
                    story.hasCigarette = true;
                }
                else
                {
                    story.Smoke();
                }
            }
            Destroy(gameObject);
        }
    }
}
