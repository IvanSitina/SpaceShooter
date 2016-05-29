using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBulletGO;
    GameObject scoreUITextGO;
    public GameObject ExplosionGO;
    float speed;
	// Use this for initialization
	void Start () {
        speed = 2f;
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
        Invoke("FireEnemyBullet", 1f);

        if (scoreUITextGO.GetComponent<GameScore>().Score > 500)
        {
            Invoke("FireEnemyBullet", 0.5f);
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 1000)
        {
            Invoke("FireEnemyBullet", 0.5f);
            Invoke("FireEnemyBullet", 1.5f);
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 1500)
        {
            Invoke("FireEnemyBullet", 0.1f);
            Invoke("FireEnemyBullet", 0.5f);
            Invoke("FireEnemyBullet", 1.5f);
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 2000)
        {
            Invoke("FireEnemyBullet", 0.1f);
            Invoke("FireEnemyBullet", 0.5f);
            Invoke("FireEnemyBullet", 1.5f);
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
}
