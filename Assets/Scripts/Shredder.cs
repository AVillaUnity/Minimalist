using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shredder : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if currently in Game build
        if (collision.gameObject.tag == "Projectile")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                GameObject enemy = collision.gameObject.GetComponent<Projectile>().EnemyParent;
                enemy.GetComponentInChildren<AmmoManager>().OnProJectileDestroyed();
            }
            Destroy(collision.gameObject);
        }
    }
}
