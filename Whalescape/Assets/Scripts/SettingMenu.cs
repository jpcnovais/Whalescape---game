using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{

    [SerializeField] GameObject pausaMenu;
    [SerializeField] GameObject settingsMenu;
    public Slider masterVolume, musicVolume;
    public AudioMixer mainAudioMixer;


    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("masterVolume", masterVolume.value);
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("musicVolume", musicVolume.value);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void CloseSettings()
    {
        pausaMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

}
