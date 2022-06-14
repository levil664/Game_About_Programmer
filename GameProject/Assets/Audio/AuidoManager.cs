using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidoManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audio;

    void Start()
    {
        audioSource.Play();
    }
}
