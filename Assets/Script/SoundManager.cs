using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip jump;
    public AudioClip click;
    public AudioClip coin;

    public bool muted;

    public void ToggleMuted()
    {
        muted = !muted;
        musicSource.mute = muted;
    }

    public void PlayJumpSfx()
    {
        if (muted) return;
        sfxSource.PlayOneShot(jump, 1);
    }

    public void PlayClickSfx()
    {
        if (muted) return;
        sfxSource.PlayOneShot(click, 1);
    }

    public void PlayCoinSfx()
    {
        if (muted) return;
        sfxSource.PlayOneShot(coin, 1);
    }
}
