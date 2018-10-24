using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class barScript : MonoBehaviour {

	public Image healthImage;
	public Text valueText;
	//public Text scoreText;

	void Start () {
	
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}

	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			DamagebyInpact playerValues = player.GetComponent<DamagebyInpact> ();
			PlayerControls playerfullHealth = player.GetComponent<PlayerControls> ();
			float playerHealth = playerValues.health;
			if (playerHealth < 0) {
				healthImage.fillAmount = 0;
				valueText.text = "% 0"; 
			} else {
				healthImage.fillAmount = Map (playerHealth, 0, playerfullHealth.fullHealth, 0, 1);
				valueText.text = "% " + playerHealth; 
			}

		}
		/*
		PlayerControls Player = player.GetComponent<PlayerControls> ();
		int playerScore = Player.score;
		scoreText.text = "" + playerScore; 
		*/
	}
}
