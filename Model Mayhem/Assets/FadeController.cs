using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    float max;
    float fadeTimer;
    bool fading;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            if (fadeTimer > 0)
            {
                fadeTimer -= Time.deltaTime;
                if (fadeTimer < 0)
                {
                    fadeTimer = 0;
                }
            }

            Color color = sr.color;
            color.a = fadeTimer / max;
            sr.color = color;
        }
    }

    public void FadeAway(float time)
    {
        max = time;
        fadeTimer = time;
        fading = true;
    }
}
