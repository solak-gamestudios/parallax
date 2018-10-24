using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	
	public float speed;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.AddForce (transform.up * speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
