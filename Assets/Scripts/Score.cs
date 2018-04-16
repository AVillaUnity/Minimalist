using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] Text scoreText = null;
    [SerializeField] Text gameOverscoreText = null;
    [SerializeField] Text highscoreText = null;
    [SerializeField] GameObject highscoreNotification = null;

    private float scoreTimer1 = 0f;
    private float scoreTimer2 = 0f;


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
        float succesiveTime = 0f;
        float timeToGetBonus = 1.1f;
        score++;
        scoreText.text = score.ToString();

        if(score > PlayerPrefsManager.GetHighscore())
        {
            UpdateHighscore(score);
        }
    
        gameOverscoreText.text = scoreText.text;
        scoreText.color = enemyColor;

        // Check for succesive points.
        // too late for bonus
        if ((Time.time - scoreTimer1) > timeToGetBonus)
        {
            ResetTimer();
        }

        if (scoreTimer1 <= 0)
        {
            scoreTimer1 = Time.time;
        }
        else
        {
            scoreTimer2 = Time.time;
        }
        if(scoreTimer1 > 0 && scoreTimer2 > 0)
        {
            succesiveTime = scoreTimer2 - scoreTimer1;
            //print(succesiveTime);
            if(succesiveTime <= timeToGetBonus)
            {
                //print("bonus!");
                DoBonus();
            }
            ResetTimer();
        }
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

    void DoBonus()
    {
        canvasAnimator.SetTrigger("bonusAchieved");
    }

    public void ResetTimer()
    {
        scoreTimer1 = 0;
        scoreTimer2 = 0;
    }


}
