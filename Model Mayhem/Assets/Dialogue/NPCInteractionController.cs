using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionController : MonoBehaviour
{

    SpeakerController speaker;
    NavController nav;

    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<SpeakerController>();
        nav = GetComponent<NavController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speaker.isTalking && nav.target == null)
        {
            nav.target = GameObject.FindGameObjectWithTag("Player").transform;
        } else
        {
            nav.target = null;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player" && !speaker.isTalking)
        {
            Debug.Log("hello");
            speaker.StartSpeaking("");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item" && !speaker.isTalking)
        {
            speaker.StartSpeaking(collision.gameObject.GetComponent<ItemController>().itemType);
        }
    }
}
