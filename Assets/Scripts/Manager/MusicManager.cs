using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip buttonEffect;

    public void PlayButtonSoundEffect()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonEffect, 7f);
    }
}
