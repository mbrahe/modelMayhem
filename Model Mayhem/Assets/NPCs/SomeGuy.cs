using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeGuy : SpeakerController
{
    public Texture placeholder;
    int possibleConversations;
    int currentConversation;
    bool[] usedConversations;

    private void Start()
    {
        usedConversations = new bool[3];
    }

    protected override void SetupConversation(string topic)
    {
        currentConversation = ConversationUtilities.randomUnused(usedConversations);
        if (currentConversation != -1)
        {
            usedConversations[currentConversation] = true;
        }
    }

    protected override bool Speak()
    {
        if (currentConversation == 0)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("Lately I'm so tired.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }
        } else if (currentConversation == 1)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("I wonder if I'll ever be cool someday. I hope I will!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }
        } else if (currentConversation == 2)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("The weather is so nice out.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }
        } else
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("Well, that's all I have to say.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }
        }

        return false;
    }
}
