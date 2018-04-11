using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] Text scoreText = null;
    [SerializeField] Text gameOverscoreText = null;
    [SerializeField] Text highscoreText = null;
    [SerializeField] GameObject highscoreNotification = null;


    Animator canvasAnimator = null;
    bool highscoreAchieved = false;

    int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
        highscoreText.text = PlayerPrefsManager.GetHighscore().ToString();
        canvasAnimator = GameObject.FindObjectOfType<Canvas>().GetComponent<Animator>();
    }

    public void UpdateScore(Color enemyColor)
    {
        score++;
        scoreText.text = score.ToString();

        if(score > PlayerPrefsManager.GetHighscore())
        {
            UpdateHighscore(score);
        }
    
        gameOverscoreText.text = scoreText.text;
        scoreText.color = enemyColor;
    }

    void UpdateHighscore(int highscore)
    {
        if (!highscoreAchieved)
        {
            highscoreNotification.SetActive(true);
            canvasAnimator.SetTrigger("highscoreAchieved");
            highscoreAchieved = true;
        }
        PlayerPrefsManager.SetHighscore(highscore);
        highscoreText.text = PlayerPrefsManager.GetHighscore().ToString();
    }


}
