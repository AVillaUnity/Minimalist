using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

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
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1 && level >= 0)
        {
            PlayerPrefs.SetInt(MASTER_VOLUME_KEY + level.ToString(), 1);
        }
        else
            Debug.LogError("Level Count out of bounds");
    }

    public static bool IsLevelUnlocked(int level)
    {
        if(level <= SceneManager.sceneCountInBuildSettings - 1 && level >= 0)
            return PlayerPrefs.GetInt(MASTER_VOLUME_KEY + level.ToString()) == 1;
        else
        {
            Debug.LogError("Level not in build order");
            return false;
        }
    }

    public static void SetDifficulty(float value)
    {
        if (value >= 1 && value <= 3)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, value);
        else
            Debug.LogError("Value not between 1 and 3");
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
