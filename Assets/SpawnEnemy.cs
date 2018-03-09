using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    [SerializeField] GameObject enemyPrefab = null;

    float hue, saturation, brightness;
    float spawnDelay = 8.0f;
    Color[] enemyColors = null;
    int index = 0;
    


	// Use this for initialization
	void Start () {
        enemyColors = new Color[transform.childCount];
        Color playerColor = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color;
        Color.RGBToHSV(playerColor, out hue, out saturation, out brightness);
        Spawn();
	}

    private void Update()
    {
        if (AllEnemiesAreDead())
        {
            Spawn();
        }
    }

    bool AllEnemiesAreDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
                return false;
        }
        return true;
    }

    void Spawn()
    {
        Transform freeSpawner = GetNextAvailableSpawner();
        GameObject enemy = Instantiate(enemyPrefab, freeSpawner.position, freeSpawner.rotation, freeSpawner.transform);
        AssignColor(enemy);
        if (GetNextAvailableSpawner())
        {
            Invoke("Spawn", spawnDelay);
        }

    }

    private void AssignColor(GameObject enemy)
    {
        enemy.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, saturation, saturation, brightness, brightness);
        enemy.GetComponent<TrailRenderer>().startColor = enemy.GetComponent<SpriteRenderer>().color;
        enemy.GetComponent<TrailRenderer>().endColor = enemy.GetComponent<SpriteRenderer>().color;
    }

    Transform GetNextAvailableSpawner()
    {
        foreach(Transform spawner in transform)
        {
            if(spawner.childCount <= 0)
            {
                return spawner;
            }
        }
        return null;
    }
}
