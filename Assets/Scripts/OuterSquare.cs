using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterSquare : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            GameObject enemy = collision.gameObject.GetComponent<Projectile>().FindParent();
            enemy.GetComponent<Enemy>().CanFire = true;
        }
    }
}
