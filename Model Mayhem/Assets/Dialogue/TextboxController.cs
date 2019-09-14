using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxController : MonoBehaviour
{
    string textboxText;
    public bool showTextbox;
    public bool showChoice;
    public bool nextTextbox;
    SpeakerController currentSpeaker;
    Texture currentPic;
    string[] currentChoices;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && showTextbox && !showChoice)
        {
            bool done = currentSpeaker.Next();
            if (done)
            {
                showTextbox = false;
                currentSpeaker = null;
            }
        }
    }

    void OnGUI()
    {
        if (showTextbox)
        {
            float width = .8f;
            float height = .2f;
            float yPos = .75f;
            Rect textboxRect = new Rect(Screen.width * (1 - width) / 2, Screen.height * yPos, Screen.width * width, Screen.height * height);
            GUI.Box(textboxRect, textboxText);

            Rect picRect = new Rect(textboxRect.x, textboxRect.y - currentPic.height, currentPic.width, currentPic.height);
            GUI.DrawTexture(picRect, currentPic);
        }

        if (showChoice)
        {
            float margin = .1f;
            float width = .4f;
            float height = .05f;
            float yPos = .2f;
            for (int i = 0; i < currentChoices.Length; i++)
            {
                Rect buttonRect = new Rect((1 - (margin + width)) * Screen.width, yPos * Screen.height + height * Screen.height * i, width * Screen.width, height * Screen.height);
                if (GUI.Button(buttonRect, currentChoices[i]))
                {
                    showChoice = false;
                    bool done = currentSpeaker.Next(i);
                    if (done)
                    {
                        showTextbox = false;
                        currentSpeaker = null;
                    }
                }
            }
        }
    }

    public void NewTextbox(string content, Texture pic, SpeakerController speaker)
    {
        textboxText = content;
        showTextbox = true;
        currentSpeaker = speaker;
        currentPic = pic;
    }

    public void NewChoice(string[] choices, SpeakerController speaker)
    {
        currentSpeaker = speaker;
        currentChoices = choices;
        showChoice = true;
    }
}
