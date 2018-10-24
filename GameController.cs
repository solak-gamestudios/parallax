using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text deathMenuText;
	public int score;
	public int shotAuto;
	public deathMenu DeathMenu;
	public GameObject[] Players;

	private int setShip;




	// Use this for initialization
	void Start () {
		score = 0;
		shotAuto = 1;
		GameObject Values = GameObject.Find ("globalValues");
		globalValues GValues = Values.GetComponent<globalValues>();
		if (GValues.barValue == 0) {
			setShip = 0;
		}else if (GValues.barValue == 0.25f) {
			setShip = 1;
		}else if (GValues.barValue == 0.5f) {
			setShip = 2;
		}else if (GValues.barValue == 0.75f) {
			setShip = 3;
		}else if (GValues.barValue == 1) {
			setShip = 4;
		}
		Instantiate (Players [setShip], transform.position, transform.rotation);
		Time.timeScale = 1;

	}
		
	// Update is called once per frame
	void Update () {
		scoreText.text = "" + score; 
		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		if (Player == null) {
			
			DeathMenu.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
		scoreText.text = "" + score;
		deathMenuText.text = "" + score;

	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
	}
}
