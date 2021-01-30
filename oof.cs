using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oof : MonoBehaviour
{
    public AudioClip oofSound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = oofSound;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GetComponent<AudioSource>().Play();           
        }
    }
}
