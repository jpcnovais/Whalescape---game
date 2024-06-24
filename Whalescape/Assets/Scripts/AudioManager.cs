using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("--------------Audio Source-----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

[Header("--------------Audio Clip-----------")]
    public AudioClip background;
    public AudioClip power;
    public AudioClip menu;
    public AudioClip damage;
    public AudioClip hit;

    AudioManager audioManager;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {   
        sfxSource.PlayOneShot(clip);
    }
}
