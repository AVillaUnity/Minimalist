using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float projectileSpeed = 1.0f;
    [SerializeField] float damage = .01f;

    Vector2 projectileVelocity;

    public float Damage
    {
        get { return damage; }
    }

    public Vector2 ProjectileVelocity
    {
        get { return projectileVelocity; }
        set { projectileVelocity = value; }
    }

    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }

    public GameObject FindParent()
    {
        Color projectileColor = GetComponent<SpriteRenderer>().color;
        foreach(Enemy enemy in GameObject.FindObjectsOfType<Enemy>())
        {
            if(enemy.GetComponent<SpriteRenderer>().color == projectileColor)
            {
                return enemy.gameObject;
            }
        }
        return null;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(projectileVelocity.x, projectileVelocity.y) * projectileSpeed * Time.deltaTime;
        transform.up = -projectileVelocity;
    }

    private void OnDrawGizmos()
    {
        
    }


}
