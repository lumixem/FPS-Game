using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{    
    public AudioClip[] audioArray;   
    public Transform player;

    bool playerMovement
    {
        get
        {
            if (Input.GetKey("w") ||
                Input.GetKey("a") ||
                Input.GetKey("s") ||
                Input.GetKey("d"))
                return true;
            else
                return false;
        }
    }

    void Update()
    {       
        if (playerMovement)
        {
            playAudio();
        }
    }

    void playAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.clip = tablica[Random.Range(0, audioArray.Length)];
            audio.Play();
        }
    }
}
