using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    [SerializeField] GameObject enemyPrefab = null;

    public static int enemyCounter = 0;

    private int enemiesAllowed = 0;

    float spawnDelay = 0.5f;
    Color[] enemyColors = null;
    int index = 0;
    


	// Use this for initialization
	void Start () {
        enemyColors = new Color[transform.childCount];
        enemyCounter = 0;
        enemiesAllowed = 0;
}

    private void Update()
    {
        if (enemyCounter <= 0)
        {
            enemiesAllowed++;
            if (enemiesAllowed > transform.childCount)
            {
                enemiesAllowed = 0;
            }
            Spawn();
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
        enemy.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, .99f, .99f, .70f, .70f);
        enemy.GetComponent<TrailRenderer>().startColor = enemy.GetComponent<SpriteRenderer>().color;
        enemy.GetComponent<TrailRenderer>().endColor = enemy.GetComponent<SpriteRenderer>().color;
    }

    Transform GetNextAvailableSpawner()
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
