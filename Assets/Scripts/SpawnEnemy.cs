using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    [SerializeField] GameObject enemyPrefab = null;

    public static int enemyCounter = 0;

    private int enemiesAllowed = 0;
    private float spawnDelay = 0.5f;
    private List<float> enemyColors;
    private Score score;
    


	// Use this for initialization
	void Start () {
        enemyColors = new List<float>();
        score = GameObject.FindObjectOfType<Score>();
        enemyCounter = 0;
        enemiesAllowed = 0;
        AmmoManager.UpdateAmmo(5, 5);
    }

    private void Update()
    {
        if (enemyCounter <= 0)
        {
            score.ResetTimer();
            enemyColors.Clear();
            enemiesAllowed++;
            if(enemiesAllowed > 1)
            {
                AmmoManager.UpdateAmmo(AmmoManager.minAmmo + 1, AmmoManager.minAmmo * 2);
            }
            if (enemiesAllowed > transform.childCount)
            {
                enemiesAllowed = 0;
            }
            Spawn();
            //print("(" + AmmoManager.minAmmo + ", " + AmmoManager.maxAmmo + ")");
        }
        
    }

    void Spawn()
    {
        Transform freeSpawner = GetNextAvailableSpawner();
        GameObject enemy = Instantiate(enemyPrefab, freeSpawner.position, freeSpawner.rotation, freeSpawner.transform);
        AssignColor(enemy);
        enemyCounter++;
        if (enemyCounter < enemiesAllowed)
        {
            Invoke("Spawn", spawnDelay);
        }

    }

    private void AssignColor(GameObject enemy)
    {
        float hue = Mathf.Round(Random.Range(0f, 20f));
        while (enemyColors.Contains(hue))
        {
            hue = Mathf.Round(Random.Range(0f, 20f));
        }
        enemyColors.Add(hue);
        enemy.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue * 16f / 320f, .99f, .70f);
        enemy.GetComponent<TrailRenderer>().startColor = enemy.GetComponent<SpriteRenderer>().color;
        enemy.GetComponent<TrailRenderer>().endColor = enemy.GetComponent<SpriteRenderer>().color;
    }

    private Transform GetNextAvailableSpawner()
    {
        Transform spawner = null;
        bool spawnFound = false;
        while (!spawnFound)
        {
            spawner = transform.GetChild(Random.Range(0, transform.childCount));
            if (spawner.childCount <= 0)
                spawnFound = true;
        }
        return spawner;
    }
}
