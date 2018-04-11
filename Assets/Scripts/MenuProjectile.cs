using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuProjectile : MonoBehaviour {

    [SerializeField] GameObject projectile = null;
    [SerializeField] Vector2 velocity = new Vector2(0f, 0f);

    void Start () {
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        //Instantiate with enemy color     
        GameObject firedProjectile = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, -0.5f), Quaternion.identity);
        firedProjectile.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, .99f, .99f, .70f, .70f);
        firedProjectile.GetComponent<Light>().color = firedProjectile.GetComponent<SpriteRenderer>().color;

        //Set trail Color
        firedProjectile.GetComponent<TrailRenderer>().startColor = firedProjectile.GetComponent<SpriteRenderer>().color;
        firedProjectile.GetComponent<TrailRenderer>().endColor = firedProjectile.GetComponent<SpriteRenderer>().color;

        // Set Projectile velocity
        float speed = firedProjectile.GetComponent<Projectile>().ProjectileSpeed;
        firedProjectile.GetComponent<Projectile>().ProjectileVelocity = velocity;
        Invoke("SpawnProjectile", 7f);
    }
}
