using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource dolbyAudio;
    private void Start()
    {
        instance = this;
        dolbyAudio = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip,float volume)
    {
        dolbyAudio.PlayOneShot(clip, volume);
    }
}
