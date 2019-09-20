using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource audio;
    public AudioClip other;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            AudioClip temp = audio.clip;
            audio.clip = other;
            other = temp;
            audio.Play();
        }
    }
}
