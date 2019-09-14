using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : SpeakerController
{
    public Texture placeholder;
    protected override bool Speak()
    {
        switch (convCounter)
        {
            case 0:
                textbox.NewTextbox("Hello there buddy", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 1:
                textbox.NewTextbox("Hello there again!", placeholder, gameObject.GetComponent<SpeakerController>());
                break;
            case 2:
                textbox.NewChoice(new string [] {"This is option one", "This is option two"}, gameObject.GetComponent<SpeakerController>());
                break;
            case 3:
                if (selection == 0)
                {
                    textbox.NewTextbox("You picked option 1", placeholder, gameObject.GetComponent<SpeakerController>());
                } else
                {
                    textbox.NewTextbox("You picked option 2", placeholder, gameObject.GetComponent<SpeakerController>());
                }
                break;
            case 4:
                return true;

        }

        return false;
    }
}
