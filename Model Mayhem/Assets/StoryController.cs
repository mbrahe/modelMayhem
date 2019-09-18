﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{

    public float timeSpeed = .03f; // how much time passes a second
    public float ennuiSpeed = .5f;

    public float time;      // 0 represents 10AM day 1, 24 represents 10AM day 2

    public float filthiness; // Ranges from 0 to 100
    public float ennui;
    public float coolness;    // Ranges from 0 to 100

    // Discrete story actions
    public bool hasHat;
    public bool hasSunglasses;
    public bool hasDeodorant;
    public bool hasTowel;
    public bool slept;
    public bool showered;

    // Variables for individual npcs

    private void Update()
    {
        time += timeSpeed * Time.deltaTime;
        ennui += ennuiSpeed * Time.deltaTime;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 20), string.Concat("Odor: ", Mathf.FloorToInt(filthiness).ToString()));
        GUI.Label(new Rect(0, 20, 100, 20), string.Concat("Ennui: ", Mathf.FloorToInt(ennui).ToString()));

        int hour = Mathf.FloorToInt(time + 10);
        int minutes = Mathf.FloorToInt((time + 10 - hour) * 60);
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 20), string.Concat(hour.ToString("00"), ":", minutes.ToString("00")));
    }
}
