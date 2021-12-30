using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager instance { get { return _instance; } }

    [SerializeField] AudioSource musicAS;
    [SerializeField] AudioSource sfxAS;

    public SoundType[] audioClips;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        PlayMusic(Sounds.BackGround);
    }
    public void PlaySfx(Sounds sound)
    {
        AudioClip soundClip = GetClip(sound);
        if (soundClip != null)
        {
            sfxAS.PlayOneShot(soundClip);
        }
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip soundClip = GetClip(sound);
        if (soundClip != null)
        {
            musicAS.clip = soundClip;
            musicAS.Play();
        }
    }
    public AudioClip GetClip(Sounds _clipType)
    {
        SoundType item = Array.Find(audioClips, i => i.clipType == _clipType);
        if (item != null)  return item.clip;
        return null;
    }
}
[Serializable]
public class SoundType
{
    public Sounds clipType;
    public AudioClip clip;
}

public enum Sounds
{
    BackGround,
    ButtonClick,
    Death,
    KeyCollect,
    EnemyDeath,
    TelePortUse
    
}
