using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class AudiosData
{
    public string name;
    public AudioClip audio;
    public AudioMixerGroup mixer;
}

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> AudioSource = new List<AudioSource>();
    public List<AudiosData> sounds = new List<AudiosData>();

    [SerializeField]
    private Dictionary<string, AudiosData> _items = new Dictionary<string, AudiosData>();

    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        AudioSource[] init;
        init = GetComponentsInChildren<AudioSource>();
        for (int i = 0; i < init.Length; i++)
        {
            AudioSource.Add(init[i]);
        }

        for (int i = 0; i < sounds.Count; i++) 
        { 
            _items.Add(sounds[i].name, sounds[i]); 
        }
    }

    public void PlayMusic(string s)
    {
        bool played = false;
        for (int i = 0; i < AudioSource.Count; i++)
        {
            if ((AudioSource[i].clip == null || !AudioSource[i].isPlaying) && !played)
            {
                AudioSource[i].clip = _items[s].audio;
                AudioSource[i].outputAudioMixerGroup = _items[s].mixer;
                AudioSource[i].loop = true;
                AudioSource[i].volume = 1;
                AudioSource[i].pitch = 1;
                AudioSource[i].Play();
                played = true;
            }
        }
    }

    public void PlayAudio(string s)
    {
        bool played = false;
        for (int i = 0; i < AudioSource.Count; i++)
        {
            if ((AudioSource[i].clip == null || !AudioSource[i].isPlaying) && !played)
            {
                AudioSource[i].clip = _items[s].audio;
                AudioSource[i].outputAudioMixerGroup = _items[s].mixer;
                AudioSource[i].loop = false;
                AudioSource[i].volume = 1;
                AudioSource[i].pitch = 1;
                AudioSource[i].Play();
                played = true;
            }
        }
    }

    public void StopAudio(string s)
    {
        for (int i = 0; i < AudioSource.Count; i++)
        {
            if (AudioSource[i].clip == _items[s].audio)
            {
                AudioSource[i].Stop();
            }
        }
    }

    public void StopAllAudios()
    {
        for (int i = 0; i < AudioSource.Count; i++)
        {

            AudioSource[i].Stop();
        }
    }
}