using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    [SerializeField] float fadeInTime = 1;
    [SerializeField] float fadeOutTime = 1;
    [SerializeField] Image panel = null;
    private Color color = Color.black;

    public bool fadeOutFinished = false;

	// Use this for initialization
	void Start () {
        StartCoroutine("PanelFadeIn");
    }

    public IEnumerator PanelFadeIn()
    {
        float counter = 0f;

        while(counter < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            color.a -= alphaChange;
            panel.color = color;
            counter += alphaChange;
            yield return null;
        }
        panel.gameObject.SetActive(false);
    }

    public IEnumerator PanelFadeOut()
    {
        panel.gameObject.SetActive(true);
        float counter = 0f;
        fadeOutFinished = false;

        while (counter < fadeOutTime)
        {
            float alphaChange = Time.deltaTime / fadeOutTime;
            color.a += alphaChange;
            panel.color = color;
            counter += alphaChange;
            yield return null;
        }
        fadeOutFinished = true;
    }
}
