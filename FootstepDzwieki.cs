using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepDzwieki : MonoBehaviour
{    
    public AudioClip[] tablica;   
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
        //if (transform.hasChanged)
        //{
        //    playAudio();
        //}   

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
            audio.clip = tablica[Random.Range(0, tablica.Length)];
            audio.Play();
        }
    }

}
