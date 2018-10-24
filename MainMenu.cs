using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GoogleMobileAds.Api;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class MainMenu : MonoBehaviour {

	public string sceneName;
	public Text scoreValue;	
	public Text HightestscoreValue;	
	public Text ShipPrice;
	public Button UnlockButton;
	public Image LockImage;
	public GameObject UnlockBox;
	public GameObject InfoBox;
	public GameObject Exit;
	//public Text HighestScore;
	public Scrollbar bar;
	public bool isTaken;
	private int pS1, pS2, pS3, pS4, pS5, HigherScoreN;
	public int TotalScoreforcount;
	private int ship;
	private string GPSData;


	public void PlayGame () {
		if (isTaken) {
			SceneManager.LoadScene (sceneName);
		}
	}

	public void QuitGame () {
		
		Application.Quit ();

	}
		
	public void ShowLeaderBoard () {

		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI ("CgkIk43W2IsIEAIQAQ");
		//Social.ShowLeaderboardUI ("CgkIk43W2IsIEAIQAQ");

	}

	void Start(){
		if (File.Exists (Application.persistentDataPath + "/saveFile.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream saveFile = File.Open (Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (saveFile);
			scoreValue.text = "" + data.TotalScore;
			HightestscoreValue.text = "" + data.HigherScore;
			HigherScoreN = data.HigherScore;
			TotalScoreforcount = data.TotalScore;
			//HighestScore.text = "" + data.HigherScore;
			pS1 = data.S1;
			pS2 = data.S2;
			pS3 = data.S3;
			pS4 = data.S4;
			pS5 = data.S5;
			saveFile.Close ();

		}else{

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream saveFile = File.Create (Application.persistentDataPath + "/saveFile.dat");
			PlayerData data = new PlayerData ();
			data.TotalScore = 0;
			data.HigherScore = 0;
			bf.Serialize (saveFile, data);
			saveFile.Close ();
		}
		if (pS5 == 1) {
			bar.value = 1.0f;
		} else if (pS4 == 1) {
			bar.value = 0.75f;
		} else if (pS3 == 1) {
			bar.value = 0.5f;
		} else if (pS2 == 1) {
			bar.value = 0.25f;
		} else if (pS1 == 1) {
			bar.value = 0.0f;
		}
	}

	public void SetMute(){

		if (AudioListener.volume == 0) {
			AudioListener.volume = 1;
		} else {
			AudioListener.volume = 0;
		}
	}

	public void ShowTropy(){
	
		// show achievements UI
		Social.ShowAchievementsUI();
	
	}

	public void changeShipValue(){
		
		UnlockBox.gameObject.SetActive (true);
	}

	public void Left(){
	
		GameObject Values = GameObject.Find ("globalValues");
		globalValues GValues = Values.GetComponent<globalValues>();
		if (GValues.barValue != 0) {
			bar.value -= 0.25f;
		}
	}

	public void Right(){

		GameObject Values = GameObject.Find ("globalValues");
		globalValues GValues = Values.GetComponent<globalValues>();
		if (GValues.barValue != 1) {
			bar.value += 0.25f;
		}
	}

	public void TakeShip () {

		GameObject Values = GameObject.Find ("globalValues");
		globalValues GValues = Values.GetComponent<globalValues>();
		float pickedShip = GValues.barValue;
		if (GValues.barValue == 0) {
			//
		}else if (GValues.barValue == 0.25f) {
			ship = 2;
		}else if (GValues.barValue == 0.5f) {
			ship = 3;
		}else if (GValues.barValue == 0.75f) {
			ship = 4;
		}else if (GValues.barValue == 1) {
			ship = 5;
		}

		//Start ();

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream saveFile = File.Open (Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
		PlayerData data = new PlayerData ();
		if (ship == 2) {
			data.S2 = 1;
			data.S3 = pS3;
			data.S4 = pS4;
			data.S5 = pS5;
			data.TotalScore = TotalScoreforcount - 2000;
			data.HigherScore = HigherScoreN;
		} else if (ship == 3) {
			data.S2 = pS2;
			data.S3 = 1;
			data.S4 = pS4;
			data.S5 = pS5;
			data.TotalScore = TotalScoreforcount - 10000;
			data.HigherScore = HigherScoreN;
			Social.ReportProgress("CgkIk43W2IsIEAIQAw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}else if (ship == 4) {
			data.S2 = pS2;
			data.S3 = pS3;
			data.S4 = 1;
			data.S5 = pS5;
			data.TotalScore = TotalScoreforcount - 30000;
			data.HigherScore = HigherScoreN;
		}else if (ship == 5) {
			data.S2 = pS2;
			data.S3 = pS3;
			data.S4 = pS4;
			data.S5 = 1;
			data.TotalScore = TotalScoreforcount - 50000;
			data.HigherScore = HigherScoreN;
			Social.ReportProgress("CgkIk43W2IsIEAIQBA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		bf.Serialize (saveFile, data);
		saveFile.Close ();

		UnlockBox.gameObject.SetActive (false);
		Start ();
	}

	public void DontTakeShip (){
		
		UnlockBox.gameObject.SetActive (false);
	
	}

	public void ForExit (){

		Exit.gameObject.SetActive (true);

	}

	public void DontExit (){

		Exit.gameObject.SetActive (false);

	}

	public void InfoScreen () {
	
		InfoBox.gameObject.SetActive (true);
	
	}

	void Update () {


		//Start ();

		//Gemi Kontrol
		GameObject Values = GameObject.Find ("globalValues");
		globalValues GValues = Values.GetComponent<globalValues>();
		float pickedShip = GValues.barValue;
		if (GValues.barValue == 0) {
			isTaken = true;
		}else if (GValues.barValue == 0.25f) {
			if (pS2 == 0) {
				isTaken = false;
			} else {
				isTaken = true;
			}
		}else if (GValues.barValue == 0.5f) {
			if (pS3 == 0) {
				isTaken = false;
			} else {
				isTaken = true;
			}
		}else if (GValues.barValue == 0.75f) {
			if (pS4 == 0) {
				isTaken = false;
			} else {
				isTaken = true;
			}
		}else if (GValues.barValue == 1) {
			if (pS5 == 0) {
				isTaken = false;
			} else {
				isTaken = true;
			}
		}
		//

		//Gemi Kilitleri.
		GValues.barValue = bar.value;
		if (GValues.barValue == 0) {
			ShipPrice.text = "";
			LockImage.gameObject.SetActive (false);
			UnlockButton.gameObject.SetActive (false);
		}else if (GValues.barValue == 0.25f) {
			ShipPrice.text = "2000";
			if (pS2 == 0 && TotalScoreforcount > 2000) { 
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (true);
			} else if (pS2 == 0) { //Gemi Değeri. 
				LockImage.gameObject.SetActive (true);
				UnlockButton.gameObject.SetActive (false);
			} else if (pS2 == 1) {
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (false);
			}
		}else if (GValues.barValue == 0.5f) {
			ShipPrice.text = "10000";
			if (pS3 == 0 && TotalScoreforcount > 10000) {
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (true);
			} else if (pS3 == 0) { //Gemi Değeri.
				LockImage.gameObject.SetActive (true);
				UnlockButton.gameObject.SetActive (false);
			} else if (pS3 == 1) {
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (false);
			}
		}else if (GValues.barValue == 0.75f) {
			ShipPrice.text = "30000";
			if (pS4 == 0 && TotalScoreforcount > 30000) {
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (true);
			} else if (pS4 == 0) { //Gemi Değeri. 
				LockImage.gameObject.SetActive (true);
				UnlockButton.gameObject.SetActive (false);
			} else if (pS4 == 1) {
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (false);
			}
		}else if (GValues.barValue == 1) {
			ShipPrice.text = "50000";
			if (pS5 == 0 && TotalScoreforcount > 50000) {
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (true);
			} else if (pS5 == 0) { //Gemi Değeri.
				LockImage.gameObject.SetActive (true);
				UnlockButton.gameObject.SetActive (false);
			} else if (pS5 == 1) { 
				LockImage.gameObject.SetActive (false);
				UnlockButton.gameObject.SetActive (false);
			}
		}
	}
}

[Serializable]
class PlayerData {
	public int TotalScore;
	public int HigherScore;
	public int S1 = 1;
	public int S2 = 0;
	public int S3 = 0;
	public int S4 = 0;
	public int S5 = 0;
}
