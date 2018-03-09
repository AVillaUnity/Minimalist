using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadAfter;

    private void Start()
    {
        if (autoLoadAfter <= 0)
            Debug.Log("Auto load disabled");
        else
            Invoke("LoadNextLevel", autoLoadAfter);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
