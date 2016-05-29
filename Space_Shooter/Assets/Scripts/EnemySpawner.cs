﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    
    public GameObject EnemyGO;
    float maxSpawnRateInSeconds = 5f;
	// Use this for initialization
	void Start () {
        
	}   
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
            float spawnInNSeconds;

<<<<<<< HEAD
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(0.001f, maxSpawnRateInSeconds);
        }
        else
        { spawnInNSeconds = 1f; }
=======
            if (maxSpawnRateInSeconds > 1f)
            {
                spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
            }
            else
            { spawnInNSeconds = 1f; }
>>>>>>> development

            Invoke("SpawnEnemy", spawnInNSeconds);
      
        
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

    public void ScheduleEnemySpawner()
    {
        maxSpawnRateInSeconds = 5f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
