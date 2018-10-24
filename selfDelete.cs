using UnityEngine;
using System.Collections;

public class selfDelete : MonoBehaviour {

	public float timer = 3.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, timer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
