﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{

    public float timeSpeed = .03f; // how much time passes a second
    public float ennuiSpeed = .5f;
    public float smokeJoy = 10;
    public float smokeOdor = 5;

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

    GameObject player;

    // Variables for individual npcs

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        time += timeSpeed * Time.deltaTime;
        ennui += ennuiSpeed * Time.deltaTime;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 20), string.Concat("Odor: ", Mathf.FloorToInt(filthiness).ToString()));
        GUI.Label(new Rect(0, 20, 100, 20), string.Concat("Ennui: ", Mathf.FloorToInt(ennui).ToString()));


        int hour = Mathf.FloorToInt(time);
        int minutes = Mathf.FloorToInt((time - hour) * 60);
        hour += 10;
        if (hour > 24)
        {
            hour -= 24;
        }

        string AMPM = "AM";

        if (hour > 12)
        {
            hour -= 12;
            AMPM = "PM";
        } 

        GUI.Label(new Rect(Screen.width - 100, 0, 100, 20), string.Concat(hour.ToString("00"), ":", minutes.ToString("00"), " ", AMPM));
    }

    public void Smoke()
    {
        ennui -= smokeJoy;
        if (ennui < 0)
        {
            ennui = 0;
        }
        filthiness += smokeOdor;
        
    }
}
