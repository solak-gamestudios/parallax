using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControls : MonoBehaviour {

	public float speed;
	public float rotSpeed = 20;
	private float nextfire;
	private Rigidbody2D rb2d;

	public GameObject blueShot;
	public GameObject greenShot;
	public Transform shotSpawn;
	public Transform shotSpawnleft;
	public Transform shotSpawnright;
	public float blueFirerate;
	public float greenFirerate;
	public int shotType;
	public int fullHealth;
	private float TimeCount;

	public Sprite[] playerSprites;
	private GameObject[] Enemy;


	void Start () {
		
		rb2d = GetComponent<Rigidbody2D> ();

	}
		
	// Update is called once per frame
	void Update () {

		//Player ShotType
		if (shotType == 1 && TimeCount < 5) {
			TimeCount += Time.deltaTime;
			while (Time.time > nextfire) {
				//Invoke ("setfireCount", 5);
				nextfire = Time.time + greenFirerate;
				Instantiate (greenShot, shotSpawnleft.position, shotSpawnleft.rotation);
				Instantiate (greenShot, shotSpawnright.position, shotSpawnright.rotation);
			}
		} else {
			TimeCount = 0;
			shotType = 0;
			while (Time.time > nextfire) {
				nextfire = Time.time + blueFirerate;
				Instantiate (blueShot, shotSpawn.position, shotSpawn.rotation);
			}
		}

		//Player Movemont.
		//DualShock 4
		//float moveplayerhorizontal = Input.GetAxis ("Horizontal");
		//float moveplayervertical = Input.GetAxis ("Vertical");
		//Vector2 movement = new Vector2 (moveplayerhorizontal, moveplayervertical);
		//Touch
		float moveplayerhorizontal = CrossPlatformInputManager.GetAxis("LHorizontal");
		float moveplayervertical = CrossPlatformInputManager.GetAxis ("LVertical");
		Vector2 movement = new Vector2 (moveplayerhorizontal, moveplayervertical);
		rb2d.velocity = movement * speed * 400 * Time.deltaTime; 
		//

		// Player Rotation
		//Dualshock 4 
		//float moveleft = Input.GetAxis ("RightH");
		//float moveright = Input.GetAxis ("RightV");
		//Touch
		float moveleft = -CrossPlatformInputManager.GetAxis("RHorizontal");
		float moveright = CrossPlatformInputManager.GetAxis("RVertical");
		Quaternion playerrotation = transform.rotation;
		float z = playerrotation.eulerAngles.z;
		if (moveleft != 0.0 || moveright != 0.0) {
			z = Mathf.Atan2 (moveleft, moveright) * Mathf.Rad2Deg;
		}

		Quaternion desiredRot = Quaternion.Euler (0, 0, z);
		transform.rotation = Quaternion.Slerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

		//Player Boundaries
		//float posx = transform.position.x;
		//float posy = transform.position.y;
		Vector2 pos = transform.position;

		if (pos.x > 10) {
			pos.x = 10;
		}
		if (pos.x < -10) {
			pos.x = -10;
		}
		if (pos.y > 5.5f) {
			pos.y = 5.5f;
		}
		if (pos.y < -5.5f) {
			pos.y = -5.5f;
		}
		transform.position = pos;

	}
	//Fizik Motoru
	void FixedUpdate () {
		
	}
		
}
