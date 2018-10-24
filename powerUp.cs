using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {

	public int powerupType = 0;
	public GameObject shield;
	public GameObject leftGun;
	public GameObject rightGun;
	private int destroyCheck = 0;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (target.tag == "Player") {

			GameObject Player = GameObject.FindGameObjectWithTag ("Player");
			DamagebyInpact playerValues = Player.GetComponent<DamagebyInpact> ();
			PlayerControls playerinValues = Player.GetComponent<PlayerControls> ();
			//
			//PowerUps
			if (playerValues.islaser == 0){
				if (powerupType == 1) { //Helath
					int addHealth = playerValues.health + 100;
					if (addHealth < playerinValues.fullHealth) {
						playerValues.health += 100;
						destroyCheck = 1;
					} else if (playerValues.health == playerinValues.fullHealth) {
						destroyCheck = 0;
						} else if (addHealth >= playerinValues.fullHealth){
						playerValues.health = playerinValues.fullHealth;
						destroyCheck = 1;
					}
				} else if (powerupType == 2) { //Shield
					(Instantiate (shield, Player.gameObject.transform.position, Player.transform.rotation) as GameObject).transform.parent = Player.transform;
					destroyCheck = 1;
				} else if (powerupType == 3) { //GreenFire
					PlayerControls playerCont = playerValues.GetComponent<PlayerControls> ();
					if (playerCont.shotType == 0) {
						playerCont.shotType = 1;
						destroyCheck = 1;
					}
				}
				if (destroyCheck == 1) {
					Destroy (gameObject);
					destroyCheck = 0;
				}

			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
