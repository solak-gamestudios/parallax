using UnityEngine;
using System.Collections;

public class DamagebyInpact : MonoBehaviour {

	public int health = 0;
	public int islaser = 0;
	public int ismeteor = 0;
	public int isplayer = 0;
	public int damage = 0;
	public int scoreValue = 0;
	public GameObject laserexplosion;
	public GameObject explosion;
	Droper DroperCS;


	void Start () {
		
	}



	void Die () {
		if (ismeteor == 1) {
			DroperCS = GetComponent<Droper> ();
			DroperCS.droperFunc ();
			Destroy (gameObject);
		}
		Destroy (gameObject);
		if (islaser == 0) {
			GameObject gameController = GameObject.Find ("Game Controller");
			GameController GCValues = gameController.GetComponent<GameController> ();
			GCValues.AddScore (scoreValue);
			Instantiate (explosion, transform.position, transform.rotation);
		} else {
			Destroy (gameObject);
		}

	}

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag != "PowerUp") {
			DamagebyInpact targetDamage = target.gameObject.GetComponent<DamagebyInpact> ();
			int playerDamage = targetDamage.damage;
			if (islaser == 1) {
				health--;
				Instantiate (laserexplosion, transform.position, transform.rotation);
			}
			health = health - playerDamage;
		}
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (target.tag != "PowerUp") {
			DamagebyInpact targetDamage = target.GetComponent<DamagebyInpact> ();
			int playerDamage = targetDamage.damage;

			if (islaser == 1) {
				health--;
				Instantiate (laserexplosion, transform.position, transform.rotation);
			}
			health = health - playerDamage;
		}
	}

	void Update (){
		if (health <= 0) {
			Die ();
		}
	}
}
