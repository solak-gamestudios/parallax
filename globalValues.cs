using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class globalValues : MonoBehaviour {


	public static int globalScoreingame;
	public int globalShip;
	public float barValue;
	public static int HigherScore;
	public static globalValues GValues;
	public static float time;
	public static float minutes;


	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		minutes = time / 60;

		GameObject gameController = GameObject.Find ("Game Controller");
		if (gameController != null) {

			GameController GCValues = gameController.GetComponent<GameController> ();
			globalScoreingame = GCValues.score;
			if (HigherScore < GCValues.score) {
				HigherScore = GCValues.score;

			}
		}
			
	}
}


