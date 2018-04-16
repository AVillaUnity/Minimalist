using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHint : MonoBehaviour {

    TextMeshProUGUI hintText = null;
    int nextHint = 0;

    private void Awake()
    {
        if (PlayerPrefsManager.GetHintToggle())
            transform.parent.gameObject.SetActive(true);
        else
            transform.parent.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        hintText = transform.Find("Tutorial Text").GetComponent<TextMeshProUGUI>();
	}

    private void Update()
    {
        if (Time.timeSinceLevelLoad > 1f)
        {
            Time.timeScale = 0f;
        }
        switch (nextHint)
        {
            case 0:
                hintText.text = "Welcome to Return to Sender! The rules are simple.";
                transform.Find("Back Button").gameObject.SetActive(false);
                break;
            case 1:
                hintText.text = "Return the Arrows back to their Sender without hitting the Core.";
                transform.Find("Back Button").gameObject.SetActive(true);
                break;
            case 2:
                hintText.text = "If the Sender runs out of Arrows, you lose.";
                break;
            case 3:
                hintText.text = "If the Core get's hit, it gets smaller. If it shrinks to nothing, you lose.";
                break;
            case 4:
                hintText.text = "Returning Arrows back to their Sender makes the Core bigger.";
                break;
            case 5:
                hintText.text = "Lastly, you can touch anywhere on the screen to speed up time. Good Luck";
                break;
            case 6:
                hintText.text = "";
                PlayerPrefsManager.SetHintToggle(false);
                transform.parent.gameObject.SetActive(false);
                Time.timeScale = 1f;
                break;
        }
    }

    public void NextHint()
    {
        nextHint++;
    }

    public void PreviousHint()
    {
        nextHint--;
    }

    public void CloseTutorial()
    {
        PlayerPrefsManager.SetHintToggle(false);
        transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    //void Hint()
    //{
    //    hintText.text = "Welcome to Return to Sender! The rules are simple.";
    //    Invoke("Hint2", 5f);
    //}

    //void Hint2()
    //{
    //    hintText.text = "Return the Arrows back to their Sender without hitting the Core.";
    //    Invoke("Hint3", 5f);
    //}

    //void Hint3()
    //{
    //    hintText.text = "If the Sender runs out of Arrows, you lose.";
    //    Invoke("Hint4", 5f);
    //}

    //void Hint4()
    //{
    //    hintText.text = "If the Core get's hit, it gets smaller. If it shrinks to nothing, you lose.";
    //    Invoke("Hint5", 7f);
    //}

    //void Hint5()
    //{
    //    hintText.text = "Returning Arrows back to their Sender makes the Core bigger.";
    //    Invoke("Hint6", 5f);
    //}

    //void Hint6()
    //{
    //    hintText.text = "Lastly, you can touch anywhere on the screen to speed up time. Good Luck!";
    //    Invoke("Clear", 5f);
    //}

    void Clear()
    {
        hintText.text = "";
        PlayerPrefsManager.SetHintToggle(false);
    }
}
