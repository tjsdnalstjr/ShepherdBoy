using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public AudioClip[] sfxClips;
    public AudioClip[] bgmClips;
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public float bgmVal = 0.5f;
    public float sfxVal = 0.5f;

    private void Start()
    {
        bgmVal = 0.5f;
        sfxVal = 0.5f;
        bgmSource.volume = bgmVal;
        sfxSource.volume = sfxVal;
    }

    public void PlaySFX(int sfxNum)
    {
        sfxSource.PlayOneShot(sfxClips[sfxNum]);
    }

    public void PlayBGM(int bgmNum)
    {
        bgmSource.clip = bgmClips[bgmNum];
        bgmSource.Play();
    }

    public void SetSFXVal(float val)
    {
        sfxVal = val;
        sfxSource.volume = sfxVal;
    }

    public void SetBGMVal(float val)
    {
        bgmVal = val;
        bgmSource.volume = bgmVal;
    }
}
