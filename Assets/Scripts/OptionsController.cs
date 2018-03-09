using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public LevelManager levelManager;
    public Slider volumeSlider;
    public Slider difficultySlider;
    private MusicManager music;

    private void Start()
    {
        music = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    private void Update()
    {
        music.ChangeVolume(volumeSlider.value);
    }


    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("Main Menu");
    }

    public void RestoreDefaults()
    {
        PlayerPrefsManager.SetMasterVolume(1.0f);
        PlayerPrefsManager.SetDifficulty(1);
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
}
