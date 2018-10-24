using UnityEngine;
using System.Collections;

public class Shots : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float firerate;
	private float nextfire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		while (Time.time > nextfire) {
			nextfire = Time.time + firerate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
