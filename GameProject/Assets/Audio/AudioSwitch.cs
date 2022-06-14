using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audios;

    private int countAudios = 29;
    private int indexAudio = 0;

    private void Start()
    {
        audioSource.PlayOneShot(audios[indexAudio]);
        PlayNextTrack();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void PlayNextTrack()
    {
        while (true)
        {
            if (audioSource.clip == null)
            {
                indexAudio++;
                audioSource.PlayOneShot(audios[indexAudio]);
            }
            else if (indexAudio == countAudios - 1)
            {
                indexAudio = 0;
                audioSource.PlayOneShot(audios[indexAudio]);
            }
        }
    }
}