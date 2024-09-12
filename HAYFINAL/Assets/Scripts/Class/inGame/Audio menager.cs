using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip audioclip;
    public AudioSource[] musics;
    public AudioSource AudioSource;
    void Start()
    {
        AudioSource = AudioSource.GetComponent<AudioSource>();
        AudioSource.Play();
    }

    public void MusicChanger(int i)
    {
        if (musics != null)
        {
            musics[i].Play();
        }
    }
}
