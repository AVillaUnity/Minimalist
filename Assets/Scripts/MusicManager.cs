using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource music;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont destroy on load" + gameObject);
    }
    // Use this for initialization
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnLevelWasLoaded(int level)
    {
        music.Stop();
        AudioClip clip = levelMusicChangeArray[level];
        if (clip)
        {
            music.clip = clip;
            music.Play();
        }
    }

    public void ChangeVolume(float value)
    {
        if (value >= 0 && value <= 1)
            music.volume = value;
        else
            Debug.LogError("Music value out of bounds");
    }
}
