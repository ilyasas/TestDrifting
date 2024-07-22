using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public Toggle toggleRef;
    public Slider volumeRef;

    private void Awake()
    {
        volumeRef.value = PlayerPrefs.GetFloat("volume",0.2f);
        toggleRef.isOn = PlayerPrefs.GetInt("music", 1) == 1? true : false;
        PlayerPrefs.SetInt("music", toggleRef.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("volume", volumeRef.value);
    }
    public void Music(bool isnotMute)
    {
        PlayerPrefs.SetInt("music",isnotMute? 1 : 0);
    }

    public void MusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }
}
