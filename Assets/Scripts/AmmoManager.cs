using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour {

    public static int minAmmo = 5;
    public static int maxAmmo = 5;

    private int enemyAmmo = 0;
    private TextMeshPro ammoText = null;
    private LevelManager levelManager = null;
    

    // Use this for initialization
    void Start () {
        enemyAmmo = Random.Range(minAmmo, maxAmmo);
        ammoText = GetComponent<TextMeshPro>();
        ammoText.text = enemyAmmo.ToString();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    public bool HasAmmo()
    {
        return enemyAmmo > 0;
    }

    public void DecreaseAmmo()
    {
        enemyAmmo--;
        if(enemyAmmo >= 0)
            ammoText.text = enemyAmmo.ToString();
    }

    public void OnProJectileDestroyed()
    {
        if (enemyAmmo == 0)
            levelManager.GameOver(GetComponentInParent<SpriteRenderer>().sprite, GetComponentInParent<SpriteRenderer>().color, "Sender ran out of arrows!", true);

    }

    public static void UpdateAmmo(int min, int max)
    {
        minAmmo = min;
        maxAmmo = max;
    }
}
