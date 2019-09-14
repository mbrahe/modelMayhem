using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationUtilities
{
    public static int randomUnused(bool[] used)
    {
        // Given an array of boolean value representing whether an integer in a range has been used
        // Return an integer that hasn't been used or -1 if they've all been used
        int numberUsed = 0;
        for (int i = 0; i < used.Length; i++)
        {
            if (used[i])
            {
                numberUsed++;
            }
        }

        if (numberUsed == used.Length)
        {
            return -1;
        }

        int choice = Random.Range(0, used.Length - numberUsed);
        while (used[choice])
        {
            choice++;
        }

        return choice;
    }
}
