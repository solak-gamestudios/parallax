using UnityEngine;
using System.Collections;

public class MeteorSpawn : MonoBehaviour {

	public Transform[] spawnPoint;
	public GameObject[] meteor;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating("createMeteor", 1, 4);

	}

	void createMeteor(){
		int spawnNumber = Random.Range (0, 5);
		int meteorNumber = Random.Range (0, 5);
		Instantiate (meteor[meteorNumber], spawnPoint[spawnNumber].position, spawnPoint[spawnNumber].rotation);
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
