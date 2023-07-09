using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlay : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource audioSource;

    public void PlayRandomSound(){

        audioSource.clip = audios[Random.Range(0, audios.Length - 1)];
        audioSource.Play();

    }
  
}
