using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class saveGame : MonoBehaviour {

	private int TotalScore;
	private int HigherScore;
	private int pS1, pS2, pS3, pS4, pS5;
	private string GPSData;

	void Awake (){
	
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream saveFile = File.Open (Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
		PlayerData data = (PlayerData)bf.Deserialize (saveFile);
		TotalScore = data.TotalScore;
		HigherScore = data.HigherScore;
		pS1 = data.S1;
		pS2 = data.S2;
		pS3 = data.S3;
		pS4 = data.S4;
		pS5 = data.S5;
		saveFile.Close ();
	}

	public void Save (){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream saveFile = File.Open (Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
		PlayerData data = new PlayerData ();
		data.TotalScore = globalValues.globalScoreingame + TotalScore;
		data.HigherScore = HigherScore;
		bool Check = true;
		if (globalValues.globalScoreingame > HigherScore) {
			data.HigherScore = globalValues.globalScoreingame;
			Check = false;
		}
		// post score 12345 to leaderboard ID "")
		if (Check){
			Social.ReportScore(data.HigherScore, "", (bool success) => {
			});
		}
		
		data.S1 = pS1;
		data.S2 = pS2;
		data.S3 = pS3;
		data.S4 = pS4;
		data.S5 = pS5;
		bf.Serialize (saveFile, data);
		saveFile.Close ();
	}
}
