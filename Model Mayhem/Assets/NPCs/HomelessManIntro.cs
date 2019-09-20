using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessManIntro : SpeakerController
{
    public Texture pic;
    int possibleConversations;
    int currentConversation;
    bool[] usedConversations;
    bool talkedBefore;

    StoryController story;
    FadeController fade;

    private void Start()
    {
        usedConversations = new bool[3];
        story = GameObject.FindGameObjectWithTag("Story").GetComponent<StoryController>();
        fade = GetComponent<FadeController>();
    }

    protected override void SetupConversation()
    {
        if (!talkedBefore)
        {
            currentConversation = 0;
            talkedBefore = true;
        } else if (story.hasCigarette)
        {
            currentConversation = 1;
        }
        else
        {
            currentConversation = ConversationUtilities.randomUnused(usedConversations);
            if (currentConversation != -1)
            {
                usedConversations[currentConversation] = true;
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
                    textbox.NewTextbox("Hey there little buddy.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewTextbox("You know, no one's going to want to\ntalk to you with you smelling so bad.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    textbox.NewTextbox("Take it from me, an old pro.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 3:
                    textbox.NewTextbox("Sometimes even I must partake of a good bath.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 4:
                    textbox.NewChoice(new string[] { "I didn't choose to be so dirty", "I don't like bathing" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 5:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("What do you mean you didn't choose this?", pic, gameObject.GetComponent<SpeakerController>());
                    } else
                    {
                        textbox.NewTextbox("Yes, I understand that. Whenever you take a bath a\ntiny bit of your soul is washed away into the sewer.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 6:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("I've never seen anyone go to such extremes\nto smell so bad", pic, gameObject.GetComponent<SpeakerController>());
                        break;
                    } else
                    {
                        textbox.NewTextbox("If I were a business man I'd reharvest this\nresidue and sell it back to the masses.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 7:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("It puts my own efforts to shame.", pic, gameObject.GetComponent<SpeakerController>());
                        break;
                    }
                    else
                    {
                        textbox.NewTextbox("Alas, I gave up that life long, long ago.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 8:
                    textbox.NewTextbox("What are you doing here anyways?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 9:
                    textbox.NewChoice(new string[] { "I escaped from hell", "I have a photoshoot", "I'm not sure" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 10:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("No wonder you smell so bad. In this short\nlife of mine I've met many such as you.", pic, gameObject.GetComponent<SpeakerController>());
                    } else if (selection == 1)
                    {
                        textbox.NewTextbox("Oh, so you're a model.\nI was a model once too.", pic, gameObject.GetComponent<SpeakerController>());
                    } else
                    {
                        textbox.NewTextbox("The life of a man that smells -- \nIt's not for the unsure.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 11:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("But none have had such a stench\nas you do now.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else if (selection == 1)
                    {
                        textbox.NewTextbox("We'll discuss that later. Right now we \nhave your photoshoot to worry about.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("It's best you get clean quick.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 12:
                    textbox.NewTextbox("It turns out I'm in the perfect\nposition to help you.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 13:
                    textbox.NewTextbox("Hidden at the bottom of my pocket\nis a certain Special Deodorant.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 14:
                    textbox.NewTextbox("Though your odor is strong, this deodorant will\n make your stench tolerable to the average person.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 15:
                    textbox.NewTextbox("After that you'll need to use your own wit\n to attain true cleanliness.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 16:
                    textbox.NewTextbox("All I ask for in return is a cigarette.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 17:
                    if (story.hasCigarette)
                    {
                        textbox.NewTextbox("Oh, you already have one?\nPerfect!", pic, gameObject.GetComponent<SpeakerController>());
                        currentConversation = 1;
                        convCounter = 0;
                    } else
                    {
                        textbox.NewTextbox("I'm sure you'll find one if you wander around.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 18:
                    textbox.NewTextbox("It's quite a deal for both of us!\nSo what do you say?", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 19:
                    textbox.NewChoice(new string[] { "What if I want to smoke?", "I guess have no choice" }, gameObject.GetComponent<SpeakerController>());
                    break;
                case 20:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("Don't worry about that.", pic, gameObject.GetComponent<SpeakerController>());
                    } else
                    {
                        textbox.NewTextbox("That's the spirit.\nI've never had a single choice since birth.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 21:
                    if (selection == 0)
                    {
                        textbox.NewTextbox("You'll have plenty of time to smoke\nonce we get you clean.", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    else
                    {
                        textbox.NewTextbox("Anyways, be quick.\nI'm dying here!", pic, gameObject.GetComponent<SpeakerController>());
                    }
                    break;
                case 22:
                    return true;
            }
        } else if (currentConversation == 1)
        {
            switch (convCounter)
            {
                case 0:
                    textbox.NewTextbox("You've found one!", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 1:
                    textbox.NewTextbox("It's a bit soggy, but I don't mind.\nAs promised, I'll give you my Special Deodorant.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 2:
                    textbox.NewTextbox("But remember, the path to cleanliness--\nIt consists of more than just a little deodorant.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 3:
                    textbox.NewTextbox("You have a long journey ahead of you.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 4:
                    textbox.NewTextbox("And by the way--\nYou might want to take up smoking yourself.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 5:
                    textbox.NewTextbox("It's a crazy world we live in.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 6:
                    textbox.NewTextbox("Without some release you're sure to become an\nemotional fireball, casting cruelty on the innocent.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 7:
                    textbox.NewTextbox("It happens to me too sometimes.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 8:
                    textbox.NewTextbox("A cigarette from time to time should be enough to\nprevent you from saying anything you regret.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 9:
                    textbox.NewTextbox("Anyways, I must be on my way.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 10:
                    textbox.NewTextbox("If we meet again, I hope you'll remember me.\nFarewell, little buddy.", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 11:
                    textbox.NewTextbox("...", pic, gameObject.GetComponent<SpeakerController>());
                    fade.FadeAway(2);
                    break;
                case 12:
                    textbox.NewTextbox("(You use the Special Deodorant)", pic, gameObject.GetComponent<SpeakerController>());
                    break;
                case 13:
                    story.filthiness = 20;
                    Destroy(gameObject);
                    return true;
            }
        }

        return false;
    }
}
