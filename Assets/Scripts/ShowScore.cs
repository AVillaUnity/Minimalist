using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    [SerializeField] Text highscore = null;

    // Use this for initialization
    void Start () {
        highscore.text = PlayerPrefsManager.GetHighscore().ToString();
	}
}
