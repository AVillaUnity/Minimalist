using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;
    private Image panel;
    private Color color = Color.black;

	// Use this for initialization
	void Start () {
        panel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            color.a -= alphaChange;
            panel.color = color;
        }
        else
            gameObject.SetActive(false);
	}
}
