using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro2 : SpeakerController
{
    public Texture placeholder;
    public Camera nextCamera;
    int possibleConversations;
    int currentConversation;
    bool[] usedConversations;

    private void Start()
    {
        usedConversations = new bool[3];
        StartSpeaking("");
    }

    protected override void SetupConversation(string topic)
    {
        currentConversation = 0;
    }

    protected override bool Speak()
    {
        switch (convCounter)
        {
            case 0:
                textbox.NewTextbox("...", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 1:
                textbox.NewTextbox("My name is Bobo Chew. \nFor my whole life all I've ever wanted was fluffy hair and delicious skin.", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 2:
                textbox.NewTextbox("As a kid I was ugly and gross. \nMy skin was always covered in a fingernail's thickness of grease.", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 3:
                textbox.NewTextbox("But then one day everything changed. \nThe spectre of exercise entered my life without even asking for my permission. ", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 4:
                textbox.NewTextbox("It's too complicated to get into the details, but let's just say that\nthat year I squeezed enough grease out of myself to solve\na whole intergalactic civilization's energy problems. ", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 5:
                textbox.NewTextbox("Suddenly I was beautiful. Tales of my name spread throughout the nation. ", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 6:
                textbox.NewTextbox("Photographers begged to take a single snapshot of my beautiful flowing hair. ", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 7:
                textbox.NewTextbox("My skin, showcased on magazine cover after magazine cover, \nshined in the morning sun. ", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 8:
                textbox.NewTextbox("However, that's all gone now. For the past decade I've lived a life of depravity. \nNo longer does even a memory of my existence remain. ", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 9:
                textbox.NewTextbox("All the money I've earned is gone and in this time I haven't had a single shower. \nThe skin-grease is back and it's here to kill. ", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 10:
                textbox.NewTextbox("But just today I've decided enough is enough.", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 11:
                textbox.NewTextbox("I'm coming back for One Last Photoshoot.", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 12:
                textbox.NewTextbox("Episode 2", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 13:
                textbox.NewTextbox("The last time we saw our pal Bobo he managed to trick 16-year-old Pipi Honkbottom \ninto joining his cause.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 14:
                textbox.NewTextbox("Pipi was once a star student at The Elite School Of Delicious Treats. ", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 15:
                textbox.NewTextbox("Six months ago she gave up that life to come under the tutelage of Dr Bologna, \na former dentist who has devoted his life to helping people. ", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 16:
                textbox.NewTextbox("Some, however, question the particular means by which he enacts his aid. ", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 17:
                textbox.NewTextbox("As for Pipi, her parents are far too strict to allow a \nperson like Bobo use their shower. ", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 18:
                textbox.NewTextbox("Despite this Pipi has vowed to do all she can to help Bobo find a\nway to be clean again. ", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 19:
                textbox.NewTextbox("In the process she introduced Bobo to The Mean Old Lady, whom Pipi \nsuspects could be tempted by Bobo's infinite charm.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 20:
                textbox.NewTextbox("Bobo does not agree. ", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 21:
                textbox.NewTextbox("Fearing his charm has been all used up he has been uncharacteristically quiet.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 22:
                textbox.NewTextbox("Will Bobo find a way to bring his charm back? \nOr will he have to pursue his shower by other means?", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 23:
                textbox.NewTextbox("Find out in the next episode of: BEAUTIFUL CHEW.", null, gameObject.GetComponent<SpeakerController>());
                break;
            case 24:
                SceneManager.LoadScene(1);
                return true;
        }

        return false;
    }
}

