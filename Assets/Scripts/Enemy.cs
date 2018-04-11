using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using TMPro;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject projectile = null;
    [SerializeField] GameObject particles = null;
    [SerializeField] float shotsPerSecond = 0.5f;


    bool canFire = true;
    bool killed = false;
    GameObject player = null;
    AmmoManager ammoManager = null;
    Score score = null;
    Core core = null;

    public bool CanFire
    {
        get { return canFire; }
        set { canFire = value; }
    }

    public bool Killed
    {
        get { return killed; }
        set { killed = value; }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject gameOver = GameObject.Find("GameOver Panel");
        score = GameObject.FindObjectOfType<Score>();
        core = GameObject.FindObjectOfType<Core>();
        ammoManager = GetComponentInChildren<AmmoManager>();
    }


    // Update is called once per frame
    void Update () {
        float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle") && canFire && ammoManager.HasAmmo())
        { 
            //Instantiate with enemy color     
            GameObject firedProjectile = Instantiate(projectile, new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, -0.5f), Quaternion.identity);
            firedProjectile.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            firedProjectile.GetComponent<Light>().color = GetComponent<SpriteRenderer>().color;

            //Set trail Color
            firedProjectile.GetComponent<TrailRenderer>().startColor = GetComponent<SpriteRenderer>().color;
            firedProjectile.GetComponent<TrailRenderer>().endColor = GetComponent<SpriteRenderer>().color;

            // Set Projectile velocity
            float speed = firedProjectile.GetComponent<Projectile>().ProjectileSpeed;
            firedProjectile.GetComponent<Projectile>().ProjectileVelocity = player.transform.position - transform.GetChild(0).position;

            canFire = false;
            ammoManager.DecreaseAmmo();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            if (collision.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                DestroyEnemy();
                killed = true;
                core.IncreaseSize(collision.gameObject.GetComponent<Projectile>().Damage);
                core.HealthAnimation(GetComponent<SpriteRenderer>().color);
                score.UpdateScore(GetComponent<SpriteRenderer>().color);
            }
        } 
    }

    void DestroyEnemy()
    {
        SpawnEnemy.enemyCounter--;
        GameObject puff = Instantiate(particles, transform.position, Quaternion.identity);
        var main = puff.GetComponent<ParticleSystem>().main;
        main.startColor = GetComponent<SpriteRenderer>().color;

        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);

        Destroy(gameObject);
    }
}
