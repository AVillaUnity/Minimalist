using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerSqaure : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<Projectile>().ProjectileSpeed /= 4;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            collision.transform.parent = null;
            collision.gameObject.GetComponent<Projectile>().ProjectileSpeed *= 4;

        }
    }
}
