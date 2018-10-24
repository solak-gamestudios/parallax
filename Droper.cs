using UnityEngine;
using System.Collections;

public class Droper: MonoBehaviour {

	public GameObject[] items;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void droperFunc () {

		int itemNumber = Random.Range (0, 2);
		DamagebyInpact isDead = GetComponent<DamagebyInpact> ();
		int Luck = Random.Range (1, 5);
		if (isDead.health == 0 && Luck == 3) {
			Instantiate (items[itemNumber], transform.position, transform.rotation);
		}

	}
}
