using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : SpeakerController
{
    public Texture placeholder;
    int possibleConversations;
    int currentConversation;
    bool[] usedConversations;

    bool conversedBefore;

    private void Start()
    {
        usedConversations = new bool[2];
    }

    protected override void SetupConversation(string topic)
    {
        if (!conversedBefore)
        {
            currentConversation = 0;
            conversedBefore = true;
        }
        else
        {
            currentConversation = ConversationUtilities.randomUnused(usedConversations);
            if (currentConversation != -1)
            {
                usedConversations[currentConversation] = true;
                currentConversation += 1;
            }
        }
    }

    protected override bool Speak()
    {
        if (currentConversation == 0)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("Captain Chew, I have some information for you!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewTextbox("In the course of my research for Dr Bologna I discovered that \nthere's a certain salaryman roaming the streets.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    textbox.NewTextbox("Recently his wife died.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 3:
                    textbox.NewTextbox("This is good news for us!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 4:
                    textbox.NewTextbox("Without a wife he'll be far more willing to let someone like you sleep over \nand take a shower.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 5:
                    textbox.NewTextbox("If you can hunt him down I'm sure he'll speak to you.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 6:
                    textbox.NewTextbox("My sources say he's always looking for someone new to listen to his tales of woe. ", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 7:
                    return true;
            }
        }
        else if (currentConversation == 1)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("I wonder if I'll ever be cool like you someday.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewTextbox("Being cool is such a heavy responsibility.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    textbox.NewTextbox("Am I capable of responsibility? I stay up all night, contemplating this question.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 3:
                    return true;
            }
        }
        else if (currentConversation == 2)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("My parents installed a new toilet.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewTextbox("Some say it is the toilet of the future.\nI haven't been able to try it yet.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    textbox.NewTextbox("I wonder what kind of experience a future toilet could possibly give me?", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 3:
                    return true;
            }
        }
        else
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("You'll get a shower soon, Captain Chew. I guarantee it!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }
        }

        return false;
    }
}