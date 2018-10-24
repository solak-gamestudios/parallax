using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class followPlayer : MonoBehaviour {

	Transform player;
	private Rigidbody2D rb2d;
	public float speed;
	public float rotSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		rb2d = GetComponent<Rigidbody2D> ();
		GameObject playermove = GameObject.FindGameObjectWithTag ("Player");
		if (playermove != null) {
			player = playermove.transform;

			// Player Rotation
			Vector3 turn = player.position - transform.position;
			turn.Normalize();

			float zAngle = Mathf.Atan2 (turn.y, turn.x) * Mathf.Rad2Deg - 90;
			Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
			transform.rotation = desiredRot;//Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
			//
		}
		//Player Move
		//rb2d.AddForce (transform.up * speed);
		rb2d.velocity = transform.up * speed;



	}
}
