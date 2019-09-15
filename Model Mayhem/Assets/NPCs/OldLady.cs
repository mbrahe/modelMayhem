using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLady : SpeakerController
{
    public Texture pic;
    int possibleConversations;
    int currentConversation;
    bool[] usedHateConversations;
    bool[] usedLikeConversations;
    bool[] usedReallyLikeConversations;

    bool conversedBefore;
    bool cottonCandy;
    bool cat;

    bool lying;
    bool seduction;

    int likeAmount;

    StoryController story;

    private void Start()
    {
        usedHateConversations = new bool[6];

        story = GameObject.FindGameObjectWithTag("Story").GetComponent<StoryController>();
    }

    protected override void SetupConversation()
    {
        if (!conversedBefore)
        {
            currentConversation = 0;
            conversedBefore = true;
        }
        //else if (likeAmount < 10)
        else
        {
            currentConversation = ConversationUtilities.randomUnused(usedHateConversations);
            if (currentConversation != -1)
            {
                usedHateConversations[currentConversation] = true;
                currentConversation += 1;
            }
        }/* else if (story.filthiness > 20)
        {
            currentConversation = 5 + ConversationUtilities.randomUnused(usedLikeConversations);
            if (currentConversation != -1)
            {
                usedLikeConversations[currentConversation - 4] = true;
            }
        } else
        {
            currentConversation = 1 + ConversationUtilities.randomUnused(usedHateConversations);
            if (currentConversation != -1)
            {
                usedHateConversations[currentConversation] = true;
            }
        }*/
        //currentConversation = 6;
    }

    protected override bool Speak()
    {
        if (currentConversation == 0)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("Go away. I'm not giving you anything.", pic, gameObject.GetComponent<SpeakerController>());
                    lying = false;
                    seduction = false;
                    break;
                case 1:
                    textbox.NewChoice(new string[] { "I didn't ask for anything", "I have something for you!" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("Of course you want something", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("What could you possibly give me?", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 3:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("Why else would we be talking?", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("(Oh no, I'm lying again)\n(I better think of something.)", null, gameObject.GetComponent<SpeakerController>());
                        lying = true;
                    }
                    break;
                case 4:
                    if (!lying)
                    {
                        textbox.NewChoice(new string[] { "I have nothing else to do", "I'm lonely", "I need a shower" }, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        // Some horrible horrible lies
                        //textbox.NewChoice(new string[] { "A", "B" }, gameObject.GetComponent<SpeakerController>());
                        return true;
                    }
                    break;
                case 5:
                    if (!lying)
                    {
                        if (selection == 0)
                        {
                            textbox.NewTextbox("Maybe you could get a job", pic, gameObject.GetComponent<SpeakerController>());
                        }
                        else if (selection == 1)
                        {
                            textbox.NewTextbox("We're all lonely. That doesn't mean\nyou can talk to me!", pic, gameObject.GetComponent<SpeakerController>());
                        }
                        else if (selection == 2)
                        {
                            textbox.NewTextbox("You do!\nI'm glad you recognize that", pic, gameObject.GetComponent<SpeakerController>());
                        }
                    }
                    break;
                case 6:
                    if (!lying)
                    {
                        if (selection == 0)
                        {
                            textbox.NewChoice(new string[] { "I'm a model", "I seduce girls" }, gameObject.GetComponent<SpeakerController>());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    break;
                case 7:
                    if (!lying)
                    {
                        if (selection == 0)
                        {
                            textbox.NewTextbox("How can someone like you be a model?", pic, gameObject.GetComponent<SpeakerController>());
                        }
                        else
                        {
                            textbox.NewTextbox("...\nAre you trying to seduce me?", pic, gameObject.GetComponent<SpeakerController>());
                            seduction = true;
                        }
                    }
                    break;
                case 8:
                    if (!lying)
                    {
                        if (!seduction)
                        {
                            textbox.NewChoice(new string[] { "Some say my hair is more delicious than cotton candy", "I actually have a photo session tomorrow" }, gameObject.GetComponent<SpeakerController>());
                        }
                        else
                        {
                            textbox.NewChoice(new string[] { "Of course", "No" }, gameObject.GetComponent<SpeakerController>());
                        }
                    }
                    break;
                case 9:
                    if (!lying)
                    {
                        if (!seduction)
                        {
                            if (selection == 0)
                            {
                                textbox.NewTextbox("...I like cotton candy", pic, gameObject.GetComponent<SpeakerController>());
                                cottonCandy = true;
                                likeAmount += 5;
                            }
                            else
                            {
                                textbox.NewTextbox("Oh heaven\nAre you really the best we have?", pic, gameObject.GetComponent<SpeakerController>());
                            }
                        }
                        else
                        {
                            if (selection == 0)
                            {
                                textbox.NewTextbox("...I'll need to think about it", pic, gameObject.GetComponent<SpeakerController>());
                                likeAmount += 10;
                            }
                            else
                            {
                                textbox.NewTextbox("Oh, I see...", pic, gameObject.GetComponent<SpeakerController>());
                                likeAmount -= 3;
                            }
                        }
                    }
                    break;
                case 10:
                    if (!lying)
                    {
                        return true;
                    }
                    break;
            }

        }
        else if (currentConversation == 1)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("Shouldn't you be doing something right now?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewChoice(new string[] { "You're the one who should be doing something", "No actually. There's nothing to do" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("I'm retired!\nI'm allowed to waste my time", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("Then I'll tell you a secret", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 3:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("I spent my whole life in the shoe factory,\nwaiting for the day I could just do nothing", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("When my cat died I used to\ntell people he got hit by a car", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 4:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("So don't pretend I'm a lazy\nbum like you", pic, gameObject.GetComponent<SpeakerController>());
                        likeAmount -= 3;
                    }
                    else
                    {
                        textbox.NewTextbox("But actually,\nI stabbed him", pic, gameObject.GetComponent<SpeakerController>());
                        cat = true;
                        likeAmount += 3;
                    }
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
                    textbox.NewTextbox("You're just like a stray dog\nAll I want to do is kick you", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    return true;
            }

        }
        else if (currentConversation == 3)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("How are you still alive?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewChoice(new string[] { "I was born this way", "I don't need very much" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("That makes no sense", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("Then why are you talking to me?", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 3:
                    return true;
            }
        }
        else if (currentConversation == 4)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("If someone stabbed you\nwould you scream?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewChoice(new string[] { "No one's ever stabbed me before", "I don't scream" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("No one's ever stabbed me before either", pic, gameObject.GetComponent<SpeakerController>());
                        likeAmount += 3;
                    }
                    else
                    {
                        textbox.NewTextbox("Oh, aren't you a real cool guy, huh?", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 3:
                    return true;
            }
        }
        else if (currentConversation == 5)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("Is it hard being a model?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewChoice(new string[] { "It's very lonely", "No way, I'm a modeling master", "Is it hard being a middle-aged lady?" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("No one should be lonely\nNot even someone who smells", pic, gameObject.GetComponent<SpeakerController>());
                        likeAmount += 4;
                    }
                    else if (selection == 1)
                    {
                        textbox.NewTextbox("I wish I could be a modeling master", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("I'll have you know, many people\nfind me quite attractive!", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 3:
                    return true;
            }
        }
        else if (currentConversation == 6)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("Can I tell you a story?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewChoice(new string[] { "Why not?", "I'm busy"}, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("When I was sixteen my parents\nwent away for the weekend", pic, gameObject.GetComponent<SpeakerController>());
                        likeAmount += 5;
                    } else
                    {
                        textbox.NewTextbox("Oh, I see...", pic, gameObject.GetComponent<SpeakerController>());
                        likeAmount -= 4;
                    }
                    break;
                case 3:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("They were always trying to get away from me --\nI was a bad kid", pic, gameObject.GetComponent<SpeakerController>());
                        likeAmount += 5;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case 4:
                    textbox.NewTextbox("Anyways, I decided the best thing would\nbe to not sleep the whole weekend", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 5:
                    textbox.NewTextbox("I'd never had the chance to do\nsomething like this before", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 6:
                    textbox.NewTextbox("I drank so much coffee.\nI listened to loud music.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 7:
                    textbox.NewTextbox("Eventually I started hallucinating", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 8:
                    textbox.NewTextbox("I could feel maggots beneath my skin,\ndrilling holes through my body", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 9:
                    textbox.NewTextbox("I couldn't move. I couldn't breathe.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 10:
                    textbox.NewTextbox("Then suddenly the door opened", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 11:
                    textbox.NewTextbox("A dark figure stepped forth out\nof a shining white plane", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 12:
                    textbox.NewTextbox("The smell of rotten pineapple filled\nthe whole room", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 13:
                    textbox.NewTextbox("The figure stepped forward,\ncloser and closer", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 14:
                    textbox.NewTextbox("He was hot, like a radiator,\nhis arms so hairy", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 15:
                    textbox.NewTextbox("He reached out and --\nHe touched me!", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 16:
                    textbox.NewTextbox("I woke up\nOf course I had fallen asleep", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 17:
                    textbox.NewTextbox("I woke up screaming\nThe loudest scream I can remember", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 18:
                    textbox.NewTextbox("After this I changed\nI wasn't bad anymore", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 19:
                    textbox.NewTextbox("When my parents finally returned\nI started studying so hard", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 20:
                    textbox.NewTextbox("I got married a few years later.\nI was twenty.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 21:
                    textbox.NewTextbox("Back then that wasn't young at all.\nMy classmates married before me.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 22:
                    textbox.NewTextbox("In short -- to see a man\nso ugly, so sad,", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 23:
                    textbox.NewTextbox("I was terrified\nI wanted to grow up normal", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 24:
                    textbox.NewTextbox("And do you know what I realized\njust now?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 25:
                    textbox.NewTextbox("The man from my dream was you --\nHe looked just like you", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 26:
                    textbox.NewTextbox("That's how ugly you are --\nIt pierces space and time", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 27:
                    textbox.NewTextbox("Your ugliness haunts the dreams of\nyoung girls who no longer exist", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 28:
                    textbox.NewTextbox("That's the kind of person you are.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 29:
                    return true;
            }
        }
        return false;
    }
}