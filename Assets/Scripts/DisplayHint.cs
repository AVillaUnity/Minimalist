using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHint : MonoBehaviour {

    TextMeshProUGUI hintText = null;

	// Use this for initialization
	void Start () {
        hintText = GetComponent<TextMeshProUGUI>();
        if(PlayerPrefsManager.GetHintToggle())
            Invoke("Hint", 2f);
	}
	
	void Hint()
    {
        hintText.text = "Welcome to Return to Sender! The rules are simple.";
        Invoke("Hint2", 5f);
    }

    void Hint2()
    {
        hintText.text = "Return the Arrows back to their Sender without hitting the Core.";
        Invoke("Hint3", 5f);
    }

    void Hint3()
    {
        hintText.text = "If the Sender runs out of Arrows, you lose.";
        Invoke("Hint4", 5f);
    }

    void Hint4()
    {
        hintText.text = "If the Core get's hit, it gets smaller. If it shrinks to nothing, you lose.";
        Invoke("Hint5", 7f);
    }

    void Hint5()
    {
        hintText.text = "Returning Arrows back to their Sender makes the Core bigger.";
        Invoke("Hint6", 5f);
    }

    void Hint6()
    {
        hintText.text = "Lastly, you can touch anywhere on the screen to speed up time. Good Luck!";
        Invoke("Clear", 5f);
    }

    void Clear()
    {
        hintText.text = "";
        PlayerPrefsManager.SetHintToggle(false);
    }
}
