using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    [SerializeField] GameObject pauseUI = null; 

    public static bool isPaused = false;

    IncreaseSpeed speedPanel = null;
    LevelManager levelManager = null;

    private void Start()
    {
        speedPanel = GameObject.FindObjectOfType<IncreaseSpeed>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }



    public void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        pauseUI.SetActive(isPaused);
        speedPanel.gameObject.SetActive(!isPaused);
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        speedPanel.gameObject.SetActive(true);
    }

    public void ToMenu(string name)
    {
        isPaused = false;
        levelManager.LoadLevel(name);
        Time.timeScale = 1;
    }

    
}
