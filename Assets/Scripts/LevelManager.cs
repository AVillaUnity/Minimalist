using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Advertisements;

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

    public void GameOver(Sprite imageSprite, Color color, string reason, bool showSpriteText)
    {
        if (!gameOverPanel.activeInHierarchy)
        {
            // set up reasoning behind gameover
            gameOverPanel.transform.Find("Reason").Find("Reason Image").GetComponent<Image>().sprite = imageSprite;
            gameOverPanel.transform.Find("Reason").Find("Reason Image").GetComponent<Image>().color = color;
            gameOverPanel.transform.Find("Reason").Find("Reason Text").GetComponent<TextMeshProUGUI>().text = reason;
            if (showSpriteText)
                gameOverPanel.transform.Find("Reason").Find("Reason Image").GetChild(0).gameObject.SetActive(true);
            else
                gameOverPanel.transform.Find("Reason").Find("Reason Image").GetChild(0).gameObject.SetActive(false);
            Invoke("ShowAdGameOver", 1f);
        }
        gameOverPanel.SetActive(true);

        //Revert Time Back to Normal
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;


    }

    private void ShowAdGameOver()
    {
#if (UNITY_ANDROID || UNITY_IOS)
        Advertisement.Show();
#endif
    }
}
