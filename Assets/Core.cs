using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour {

    public delegate void OnCoreHit();
    public event OnCoreHit onCoreHit;

    [SerializeField] float maxSize = 0.3f;
    [SerializeField] GameObject injure = null;

    Color originalColor = Color.clear;


    private void Start()
    {
        transform.localScale = new Vector3(maxSize, maxSize, maxSize);
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            ReduceSize(collision.gameObject.GetComponent<Projectile>().Damage);
            InjureAnimation();

        }
        if (transform.localScale == Vector3.zero)
        {
            GameObject.FindObjectOfType<LevelManager>().LoadLevel("Lose");
        }
    }

    void ReduceSize(float factor)
    {
        transform.localScale -= new Vector3(factor, factor, factor);
    }

    public void IncreaseSize(float factor)
    {
        if(transform.localScale.x < maxSize)
        transform.localScale += new Vector3(factor, factor, factor);
    }

    void InjureAnimation()
    {
        injure.GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ResetAnimation", 0.1f);
    }

    void ResetAnimation()
    {
        injure.GetComponent<SpriteRenderer>().color = Color.clear;
    }

    public void HealthAnimation(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        Invoke("ResetCoreColor", 0.1f);
    }

    private void ResetCoreColor()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}
