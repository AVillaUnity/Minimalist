using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel = null;

    public float autoLoadAfter;
    FadeIn panel = null;

    private void Awake()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(480, 853, false);
        Screen.fullScreen = false;
#endif
    }

    private void Start()
    {
        if (autoLoadAfter <= 0)
            Debug.Log("Auto load disabled");
        else
            Invoke("LoadNextLevel", autoLoadAfter);
        panel = GameObject.FindObjectOfType<FadeIn>();
    }

    public void LoadLevel(string name)
    {
        StartCoroutine(panel.PanelFadeOut());
        StartCoroutine(StartLevel(name));
    }

    IEnumerator StartLevel(string name)
    {
        while(!panel.fadeOutFinished)
            yield return null;
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

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
