using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] private float multiplier = 30;
    [SerializeField] Toggle toggle;


    [SerializeField] private Slider masterVolumeSlider = null;
    [SerializeField] private TMP_Text masterVolumeTextUI = null;

    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private TMP_Text musicVolumeTextUI = null;

    [SerializeField] private Slider effectsVolumeSlider = null;
    [SerializeField] private TMP_Text effectsVolumeTextUI = null;

    public void MasterVolumeSlider(float volume)
    {
        masterVolumeTextUI.text = volume.ToString("0.0");
        mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * multiplier);
        toggle.isOn = masterVolumeSlider.value <= masterVolumeSlider.minValue;
    }

    public void MusicVolumeSlider(float volume2)
    {
        musicVolumeTextUI.text = volume2.ToString("0.0");
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume2) * multiplier);
        // AudioListener.volume = volume2;
    }

    public void EffectsVolumeSlider(float volume3)
    {
        effectsVolumeTextUI.text = volume3.ToString("0.0");
        mixer.SetFloat("EffectsVolume", Mathf.Log10(volume3) * multiplier);
        // AudioListener.volume = volume3;
    }

    public void MuteToggle(bool enableSound)
    {
        if (enableSound)
        {
            masterVolumeSlider.value = masterVolumeSlider.minValue;
        }
        else
        {
            masterVolumeSlider.value = 0.5f;
        }
    }




    public void SaveVolume()
    {
        float MasterVolumeValue = masterVolumeSlider.value;
        PlayerPrefs.SetFloat("MasterVolume", MasterVolumeValue);
        float MusicVolumeValue = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", MusicVolumeValue);
        float EffectsVolumeValue = effectsVolumeSlider.value;
        PlayerPrefs.SetFloat("EffectsVolume", EffectsVolumeValue);
        LoadValues();

    }
    public void LoadValues()
    {
        float MastervolumeValue = PlayerPrefs.GetFloat("MasterVolume");
        float MusicvolumeValue = PlayerPrefs.GetFloat("MusicVolume");
        float EffectsvolumeValue = PlayerPrefs.GetFloat("EffectsVolume");
        masterVolumeSlider.value = MastervolumeValue;
        musicVolumeSlider.value = MusicvolumeValue;
        effectsVolumeSlider.value = EffectsvolumeValue;

        AudioListener.volume = MastervolumeValue;
    }
}
