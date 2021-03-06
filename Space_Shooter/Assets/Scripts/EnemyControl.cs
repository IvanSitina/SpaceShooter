﻿using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
    GameObject scoreUITextGO;
    public GameObject ExplosionGO;
    float speed;
	// Use this for initialization
	void Start () {
        speed = 2f;
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            scoreUITextGO.GetComponent<GameScore>().Score += 125;

            if (scoreUITextGO.GetComponent<GameScore>().Score > 1000)
            {
                scoreUITextGO.GetComponent<GameScore>().Score += 125;
            }
            if (scoreUITextGO.GetComponent<GameScore>().Score > 5000)
            {
                scoreUITextGO.GetComponent<GameScore>().Score += 250;
            }
            if (scoreUITextGO.GetComponent<GameScore>().Score > 10000)
            {
                scoreUITextGO.GetComponent<GameScore>().Score += 250;
            }
            if (scoreUITextGO.GetComponent<GameScore>().Score > 15000)
            {
                scoreUITextGO.GetComponent<GameScore>().Score += 125;
            }
            if (scoreUITextGO.GetComponent<GameScore>().Score > 20000)
            {
                scoreUITextGO.GetComponent<GameScore>().Score += 375;
            }
            if (scoreUITextGO.GetComponent<GameScore>().Score > 25000)
            {
                scoreUITextGO.GetComponent<GameScore>().Score += 500;
            }
            if (scoreUITextGO.GetComponent<GameScore>().Score > 50000)
            {
                scoreUITextGO.GetComponent<GameScore>().Score += 1000;
            }
            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
