using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDestroyer : MonoBehaviour {

    private void Start()
    {
        PlayerPrefsManager.SetHighscore(2);
    }

    private void OnMouseDown()
    {
        GetComponent<Enemy>().DestroyEnemy();
        GameObject.FindObjectOfType<Score>().UpdateScore(GetComponent<SpriteRenderer>().color);
    }
}
