using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] Text scoreText = null;

    int score = 0;
    // Use this for initialization

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
