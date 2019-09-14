using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerController : MonoBehaviour
{

    public TextboxController textbox;

    protected int convCounter = 0;
    protected int selection = 0;

    public bool isTalking
    {
        get
        {
            return convCounter != 0;
        }
    }

    public virtual void StartSpeaking()
    {
        SetupConversation();
        Next();
    }

    protected virtual void SetupConversation()
    {
        return;
    }
    protected virtual bool Speak()
    {
        return true;
    }

    public bool Next()
    {
        bool done = Speak();

        if (done)
        {
            convCounter = 0;
            return true;
        } else
        {
            convCounter++;
            return false;
        }
    }
    public bool Next(int choice)
    {
        selection = choice;
        bool done = Speak();
        Debug.Log(done);
        if (done)
        {
            convCounter = 0;
            return true;
        }
        else
        {
            convCounter++;
            return false;
        }
    }
}
