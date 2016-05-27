﻿using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBulletGO;
	// Use this for initialization
	void Start () {
        Invoke("FireEnemyBullet", 1.5f);
        Invoke("FireEnemyBullet", 0.1f);
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
}