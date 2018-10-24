using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class meteorMover : MonoBehaviour {

	Transform player;
	public float speed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		//GameObject.FindGameObjectsWithTag ("Player");
		GameObject playermove = GameObject.FindGameObjectWithTag ("Player");
		if (playermove != null) {
			player = playermove.transform;
			Vector2 move = new Vector2 (player.transform.position.x-transform.position.x, player.transform.position.y-transform.position.y);
			rb2d.velocity = move * speed;
		}


	}
	
	// Update is called once per frame
	void Update () {
		

	
	}
}
