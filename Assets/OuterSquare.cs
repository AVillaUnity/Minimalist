using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterSquare : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            foreach (Enemy enemy in GameObject.FindObjectsOfType<Enemy>())
            {
                if(enemy.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color){
                    enemy.CanFire = true;
                    break;
                }
            }
        }
    }
}
