﻿using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBulletGO;
    GameObject scoreUITextGO;
    public GameObject ExplosionGO;
	// Use this for initialization
	void Start () {
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
        Invoke("FireEnemyBullet", 1f);

        if (scoreUITextGO.GetComponent<GameScore>().Score > 5000)
        {
            maxSpawnRateInSeconds = 4f;
            Invoke("FireEnemyBullet", 0.5f);
            
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 10000)
        {
            maxSpawnRateInSeconds = 3.5f;
            Invoke("FireEnemyBullet", 0.5f);
            Invoke("FireEnemyBullet", 1.5f);
            
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 20000)
        {
            maxSpawnRateInSeconds = 3f;
            Invoke("FireEnemyBullet", 0.1f);
            Invoke("FireEnemyBullet", 0.5f);
            Invoke("FireEnemyBullet", 1.5f);
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 25000)
        {
            maxSpawnRateInSeconds = 2.5f;
            Invoke("FireEnemyBullet", 0.1f);
            Invoke("FireEnemyBullet", 0.5f);
            Invoke("FireEnemyBullet", 1.5f);
            Invoke("FireEnemyBullet", 2f);
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 50000)
        {
            maxSpawnRateInSeconds = 0.5f;
            Invoke("FireEnemyBullet", 0.1f);
            Invoke("FireEnemyBullet", 0.3f);
            Invoke("FireEnemyBullet", 0.5f);
            Invoke("FireEnemyBullet", 0.7f);
            Invoke("FireEnemyBullet", 1.2f);
            Invoke("FireEnemyBullet", 1.5f);
            Invoke("FireEnemyBullet", 1.8f);
            Invoke("FireEnemyBullet", 2f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGO");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }


    public double maxSpawnRateInSeconds { get; set; }

    public float spawnInNSeconds { get; set; }
}
