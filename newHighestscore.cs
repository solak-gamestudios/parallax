using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class newHighestscore : MonoBehaviour {

	private int HigherScore;
	public GameObject HighScore;
	public Text HighScoretext;

	// Use this for initialization
	void Start () {
	
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream saveFile = File.Open (Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
		PlayerData data = (PlayerData)bf.Deserialize (saveFile);
		HigherScore = data.HigherScore;
		saveFile.Close ();

		if (data.HigherScore >= 0) {
			Social.ReportProgress("CgkIk43W2IsIEAIQAg", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
	}
	
	// Update is called once per frame
	void Update () {

		GameObject Player = GameObject.FindGameObjectWithTag ("Player");

		if (globalValues.globalScoreingame > HigherScore && Player == null) {
			HighScoretext.text = "" + globalValues.globalScoreingame;
			HighScore.gameObject.SetActive (true);

			// post score 12345 to leaderboard ID "Cfji293fjsie_QA")
			Social.ReportScore(globalValues.globalScoreingame, "CgkIk43W2IsIEAIQAQ", (bool success) => {
				
			});
				// handle success or failure

			if (globalValues.globalScoreingame >= 1000) {
				Social.ReportProgress("CgkIk43W2IsIEAIQBQ", 100.0f, (bool success) => {
					// handle success or failure
				});
			}
			if (globalValues.globalScoreingame >= 10000) {
				Social.ReportProgress("CgkIk43W2IsIEAIQBg", 100.0f, (bool success) => {
					// handle success or failure
				});
			}
		}
	}
}
