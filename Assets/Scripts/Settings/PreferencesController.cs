using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesController : MonoBehaviour
{
    private ScreenController _screen;
    private AudioMixerController _audio;

    private void Awake()
    {
        _screen = GetComponent<ScreenController>();
        _audio = GetComponent<AudioMixerController>();
        LoadPrefs();
    }

    private void Start()
    {
        LoadPrefs();
    }

    public void SavePrefs()
    {
        int k = (_screen.GetFullScreen() == true) ? 1 : 0;
        PlayerPrefs.SetInt("fullScreen", k);
        PlayerPrefs.SetFloat("master", _audio.GetMasterVolume());
        PlayerPrefs.SetFloat("music", _audio.GetMusicVolume());
        PlayerPrefs.SetFloat("fx", _audio.GetFxVolume());

        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        if (PlayerPrefs.HasKey("fullScreen"))
        {
            bool k = (PlayerPrefs.GetInt("fullScreen") == 1 ? true : false);
            _screen.SetFullScreen(k);
        }
        else
        {
            _screen.SetFullScreen(true);
        }
        if (PlayerPrefs.HasKey("master"))
        {
            _audio.SetMasterVolume(PlayerPrefs.GetFloat("master"));
        }
        else
        {
            _audio.SetMasterVolume(1);
        }
        if (PlayerPrefs.HasKey("music"))
        {
            _audio.SetMusicVolume(PlayerPrefs.GetFloat("music"));
        }
        else
        {
            _audio.SetMusicVolume(1);
        }
        if (PlayerPrefs.HasKey("fx"))
        {
            _audio.SetFxVolume(PlayerPrefs.GetFloat("fx"));
        }
        else
        {
            _audio.SetFxVolume(1);
        }
    }
}
