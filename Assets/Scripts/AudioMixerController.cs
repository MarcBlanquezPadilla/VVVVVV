using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider fxSlider;

    [Header("INFORMATION")]
    [SerializeField] private float master;
    [SerializeField] private float music;
    [SerializeField] private float fx;

    public void SliderMasterVolume(float sliderValue)
    {
        master = sliderValue;
        mixer.SetFloat("MasterVolume", Mathf.Log10(master) * 20);
    }

    public void SliderMusicVolume(float sliderValue)
    {
        music = sliderValue;
        mixer.SetFloat("MusicVolume", Mathf.Log10(music) * 20);
    }

    public void SliderFxVolume(float sliderValue)
    {
        fx = sliderValue;
        mixer.SetFloat("FxVolume", Mathf.Log10(fx) * 20);
    }

    public float GetMasterVolume()
    {
        return master;
    }

    public float GetMusicVolume()
    {
        return music;
    }

    public float GetFxVolume()
    {
        return fx;
    }

    public void SetMasterVolume(float masterVolume)
    {

        master = masterVolume;
        mixer.SetFloat("MasterVolume", Mathf.Log10(master) * 20);
        masterSlider.value = master;
    }

    public void SetMusicVolume(float musicVolume)
    {
        music = musicVolume;
        mixer.SetFloat("MusicVolume", Mathf.Log10(music) * 20);
        musicSlider.value = music;
    }

    public void SetFxVolume(float fxVolume)
    {
        fx = fxVolume;
        mixer.SetFloat("FxVolume", Mathf.Log10(fx) * 20);
        fxSlider.value = fx;
    }


}
