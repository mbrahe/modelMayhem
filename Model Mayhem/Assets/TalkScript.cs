using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour
{
    // Start is called before the first frame update
    SpeakerController speaker;
    bool spoke;
    void Start()
    {
        speaker = GetComponent<SpeakerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!speaker.isTalking)
        {
            speaker.StartSpeaking("");
            //spoke = true;
        }
    }
}
