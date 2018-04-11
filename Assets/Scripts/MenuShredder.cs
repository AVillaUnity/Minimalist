using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShredder : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
