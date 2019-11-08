using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : SpeakerController
{
    public Texture placeholder;
    int possibleConversations;
    int currentConversation;
    bool[] usedConversations;

    bool conversedBefore;

    private void Start()
    {
        usedConversations = new bool[1];
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
                    textbox.NewTextbox("Hey there little buddy, you caught me at the sleepiest time of the day.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewTextbox("I was actually on my way to find somewhere to take a nap.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    textbox.NewTextbox("As you know, that wife of mine has been real touchy lately.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 3:
                    textbox.NewTextbox("She keeps the door to our apartment locked at all times.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 4:
                    textbox.NewTextbox("Way back when she'd open the door for me when I knocked,\nbut I guess I did something to upset her.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 5:
                    textbox.NewTextbox("No more bedtime for me!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 6:
                    textbox.NewTextbox("For awhile I was sleeping in my office.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 7:
                    textbox.NewTextbox("One night the old man saw me there at 2am.\nHe gave me a raise for working so hard!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 8:
                    textbox.NewTextbox("Though just last month I discovered someone else has been sleeping there. ", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 9:
                    textbox.NewTextbox("Someone I've never seen before.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 10:
                    textbox.NewTextbox("I'm too scared to say anything.\nI sense a strong evil presence. ", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 11:
                    textbox.NewTextbox("Have you ever experienced true evil before?\nI don't know what happens when someone spends too much time in its vicinity.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 12:
                    textbox.NewTextbox("Anyways, the office isn't safe anymore. Now I sleep on the sidewalk.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 13:
                    textbox.NewTextbox("As the days grow colder my dreams become more and more fearsome.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 14:
                    textbox.NewTextbox("I'd like to tell you what I see at night when my eyes are closed,\nbut now is not the time!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 15:
                    textbox.NewTextbox("Maybe if you can bring something to warm me up I'll share a story or two.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 16:
                    return true;
            }
        }
        else if (currentConversation == 1)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("I'm worried I haven't been getting enough calcium.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewTextbox("Long long ago I would drink milk everyday. At least six glasses.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    textbox.NewTextbox("The milk did something to me though. It turned me into a bad person.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 3:
                    textbox.NewTextbox("Now it's been over ten years since I've drank a glass of milk.", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 4:
                    textbox.NewTextbox("I'm still young, but I don't quite have the pounce I once did.\nWhat will happen if I get osteoporosis?", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 5:
                    return true;
            }
        }
        else if (currentConversation == 2)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }
        }
        else
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("It's too cold out for me to think.\nTalk to me later!", placeholder, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }
        }

        return false;
    }
}