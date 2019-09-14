using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerController : MonoBehaviour
{

    public TextboxController textbox;

    public bool start;

    protected int convCounter = 0;
    protected int selection = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Next();
            start = false;
        }
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
