using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADVAudioPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource bgmAudioSource;
    public void PlayAudio(AudioClip audioClip)
    {
        if (audioClip == null) return;
        bgmAudioSource.clip = audioClip;
        bgmAudioSource.Play();
    }
}
