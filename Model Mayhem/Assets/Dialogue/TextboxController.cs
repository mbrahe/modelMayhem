﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxController : MonoBehaviour
{
    public float boxWidth = .8f;
    public float boxHeight = .2f;
    public float boxYPos = .75f;
    public int boxFontSize = 30;

    public float choiceRightMargin = .1f;
    public float choiceWidth = .4f;
    public float choiceHeight = .05f;
    public float choiceYPos = .4f;

    string textboxText;
    bool showTextbox;
    bool showChoice;

    SpeakerController currentSpeaker;
    Texture currentPic;
    string[] currentChoices;

    public bool inUse
    {
        get
        {
            return showTextbox || showChoice;
        }
    }


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
        GUI.skin.box.fontSize = boxFontSize;
        if (showTextbox)
        {
            Rect textboxRect = new Rect(Screen.width * (1 - boxWidth) / 2, Screen.height * boxYPos, Screen.width * boxWidth, Screen.height * boxHeight);
            GUI.Box(textboxRect, textboxText);

            Rect picRect = new Rect(textboxRect.x, textboxRect.y - currentPic.height, currentPic.width, currentPic.height);
            GUI.DrawTexture(picRect, currentPic);
        }

        if (showChoice)
        {
            for (int i = 0; i < currentChoices.Length; i++)
            {
                Rect buttonRect = new Rect((1 - (choiceRightMargin + choiceWidth)) * Screen.width, choiceYPos * Screen.height + choiceHeight * Screen.height * i, choiceWidth * Screen.width, choiceHeight * Screen.height);
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