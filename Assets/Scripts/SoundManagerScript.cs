using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip Note1, Note2, Note3, Note4, WrongNote;
    private static AudioSource _audioSource;

    private void Start()
    {
        Note1 = Resources.Load<AudioClip>("Sounds/synth1");
        Note2 = Resources.Load<AudioClip>("Sounds/synth2");
        Note3 = Resources.Load<AudioClip>("Sounds/3");
        Note4 = Resources.Load<AudioClip>("Sounds/4");
        WrongNote = Resources.Load<AudioClip>("Sounds/wrong note");

        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(int clip)
    {
        switch (clip)
        {
            case 1:
                _audioSource.PlayOneShot(Note1);
                break;
            case 2:
                _audioSource.PlayOneShot(Note2);
                break;
            case 3:
                _audioSource.PlayOneShot(Note3);
                break;
            case 4:
                _audioSource.PlayOneShot(Note4);
                break;
            case 5:
                _audioSource.PlayOneShot(WrongNote);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
