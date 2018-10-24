using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public Transform[] spawnPoint;
	public GameObject[] enemy;
	private GameObject[] EnemyCount;
	private float TimeCount;
	private float FullTimeCount;

	// Use this for initialization
	void Start () {

	}

	void createEnemy(){
		int spawnNumber = Random.Range (0, 4);
		int enemyNumber = Random.Range (1, 100);
		if (enemyNumber <= 20) {
			Instantiate (enemy [0], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
		} else if (enemyNumber > 20 && enemyNumber < 45) {
			Instantiate (enemy [1], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
		} else if (enemyNumber > 45 && enemyNumber < 80) {
			Instantiate (enemy [2], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
		} else {
			Instantiate (enemy [3], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
		}

	}

	// Update is called once per frame
	void Update () {

		TimeCount += Time.deltaTime;
		FullTimeCount += Time.deltaTime;
		EnemyCount = GameObject.FindGameObjectsWithTag ("Enemy");
		int MaxEnemy, RespawnTime;
		if (FullTimeCount <= 240) {
			MaxEnemy = 1;
			RespawnTime = 4;
		} else if (FullTimeCount > 240 && FullTimeCount <= 500) {
			MaxEnemy = 2;
			RespawnTime = 4;
		} else {
			MaxEnemy = 3;
			RespawnTime = 3;
		}
		if (TimeCount > RespawnTime && EnemyCount.Length < MaxEnemy) {
			int spawnNumber = Random.Range (0, 4);
			int enemyNumber = Random.Range (1, 100);
			if (enemyNumber <= 20) {
				Instantiate (enemy [0], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
			} else if (enemyNumber > 20 && enemyNumber < 45) {
				Instantiate (enemy [1], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
			} else if (enemyNumber > 45 && enemyNumber < 80) {
				Instantiate (enemy [2], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
			} else {
				Instantiate (enemy [3], spawnPoint [spawnNumber].position, spawnPoint [spawnNumber].rotation);
			}
			TimeCount = 0;
		}
	}
}
