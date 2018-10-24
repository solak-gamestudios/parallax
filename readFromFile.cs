using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class readFromFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		/*if (File.Exists (Application.persistentDataPath + "/saveFile.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream saveFile = File.Open (Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (saveFile);
			scoreValue.text = "" + data.TotalScore;
			//data.HigherScore;
			saveFile.Close ();

		}else{

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream saveFile = File.Create (Application.persistentDataPath + "/saveFile.dat");

		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
