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
		// post score 12345 to leaderboard ID "Cfji293fjsie_QA")
		if (Check){
			Social.ReportScore(data.HigherScore, "CgkIk43W2IsIEAIQAQ", (bool success) => {
			});
		}
		/*PlayGamesPlatform.Instance.LoadScores (
			"CgkIk43W2IsIEAIQAQ",
			LeaderboardStart.PlayerCentered,
			1,
			LeaderboardCollection.Public,
			LeaderboardTimeSpan.AllTime,
			(LeaderboardScoreData ldata) => {
				//Debug.Log (ldata.Valid);
				//Debug.Log (ldata.Id);
				//Debug.Log (ldata.PlayerScore);
				//Debug.Log (ldata.PlayerScore.userID);
				//Debug.Log (ldata.PlayerScore.formattedValue);
				GPSData = ldata.PlayerScore.formattedValue;
			});
		int intGPSData = Int32.Parse(GPSData);
		Debug.Log ("Save: " + intGPSData);
		if (intGPSData > data.HigherScore) {
			data.HigherScore = intGPSData;
		}*/
		data.S1 = pS1;
		data.S2 = pS2;
		data.S3 = pS3;
		data.S4 = pS4;
		data.S5 = pS5;
		bf.Serialize (saveFile, data);
		saveFile.Close ();
	}
}
