using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour {

    public delegate void OnCoreHit();
    public event OnCoreHit onCoreHit;

    [SerializeField] float maxSize = 0.3f;

    private AudioSource audioSource = null;
    private LevelManager levelManager = null;
    private Color originalColor = Color.clear;
    private float tempoChange = .13f;


    private void Start()
    {
        transform.localScale = new Vector3(maxSize, maxSize, maxSize);
        originalColor = GetComponent<SpriteRenderer>().color;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetSoundVolume();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool canReduce = true;
        if (collision.gameObject.tag == "Projectile" && canReduce)
        {
            audioSource.Play();
            ReduceSize(collision.gameObject.GetComponent<Projectile>().Damage);
            GameObject enemy = collision.gameObject.GetComponent<Projectile>().EnemyParent;
            enemy.GetComponentInChildren<AmmoManager>().OnProJectileDestroyed();
            Destroy(collision.gameObject);
            InjureAnimation();

        }
        if (transform.localScale == Vector3.zero)
        {
            levelManager.GameOver(GetComponent<SpriteRenderer>().sprite, GetComponent<SpriteRenderer>().color, "The Core has disappeared!", false);
            canReduce = false;
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
        Camera.main.backgroundColor = Color.red;
        Invoke("ResetAnimation", 0.1f);
    }

    void ResetAnimation()
    {
        Camera.main.backgroundColor = Color.black;
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
