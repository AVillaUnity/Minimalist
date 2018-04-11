using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string SOUND_VOLUME_KEY = "sound_volume";
    const string HINT_KEY = "hints_toggle";
    const string HIGHSCORE_KEY = "highscore";

    public static void SetMasterVolume(float value)
    {
        if (value >= 0f && value <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
        }
        else
            Debug.LogError("Master volume value out of bounds");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 1f);
    }

    public static void SetSoundVolume(float value)
    {
        if (value >= 0f && value <= 1f)
            PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, value);
        else
            Debug.LogError("Sound volume value out of bounds");
    }

    public static float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat(SOUND_VOLUME_KEY, 1f);
    }

    public static void SetHighscore(int value)
    {
        if (value >= 0)
            PlayerPrefs.SetInt(HIGHSCORE_KEY, value);
        else
            Debug.LogError("Value not greater than or equal to 0");
    }

    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
    }

    public static bool GetHintToggle()
    {
        int boolValue = PlayerPrefs.GetInt(HINT_KEY, 1);
        if (boolValue == 1)
            return true;
        else
            return false;
    }

    public static void SetHintToggle(bool value)
    {
        if (value)
            PlayerPrefs.SetInt(HINT_KEY, 1);
        else
            PlayerPrefs.SetInt(HINT_KEY, 0);
    }
}
