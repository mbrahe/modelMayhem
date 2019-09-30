using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : SpeakerController
{
    public Texture placeholder;
    public Camera nextCamera;
    int possibleConversations;
    int currentConversation;
    bool[] usedConversations;

    private void Start()
    {
        usedConversations = new bool[3];
        StartSpeaking();
    }

    protected override void SetupConversation()
    {
        currentConversation = 0;
    }

    protected override bool Speak()
    {
        switch (convCounter)
        {
            case 0:
                textbox.NewTextbox("...", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 1:
                textbox.NewTextbox("I used to be a model,\nLong, long ago.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 2:
                textbox.NewTextbox("However, after living a life of depravity I was\ncondemned to hell.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 3:
                textbox.NewTextbox("But just last night I received a phone call.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 4:
                textbox.NewTextbox("A certain photographer remembered me from my previous life.\nWe scheduled a photoshoot.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 5:
                textbox.NewTextbox("So, I escaped from hell.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 6:
                SceneManager.LoadScene(1);
                return true;
        }

        return false;
    }
}
