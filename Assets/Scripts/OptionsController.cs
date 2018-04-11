using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider = null;
    [SerializeField] Slider soundSlider = null;
    [SerializeField] Toggle hintToggle = null;
    [SerializeField] GameObject settingsPanel = null;

    private MusicManager music;

    private void Start()
    {
        music = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        soundSlider.value = PlayerPrefsManager.GetSoundVolume();
        hintToggle.isOn = PlayerPrefsManager.GetHintToggle();
    }



    private void Update()
    {
        music.ChangeVolume(volumeSlider.value);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        soundSlider.value = PlayerPrefsManager.GetSoundVolume();
        hintToggle.isOn = PlayerPrefsManager.GetHintToggle();
    }


    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetSoundVolume(soundSlider.value);
        PlayerPrefsManager.SetHintToggle(hintToggle.isOn);
        settingsPanel.SetActive(false);
    }

    public void RestoreDefaults()
    {
        volumeSlider.value = 1.0f;
        soundSlider.value = 1.0f;
        hintToggle.isOn = true;
    }
}
