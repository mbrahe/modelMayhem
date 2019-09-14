using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionController : MonoBehaviour
{

    SpeakerController speaker;

    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<SpeakerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player" && !speaker.isTalking)
        {
            Debug.Log("Hello");
            speaker.StartSpeaking();
        }
    }
}
