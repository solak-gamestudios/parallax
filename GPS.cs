using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;



public class GPS : MonoBehaviour {


	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
		PlayGamesPlatform.Activate();

		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
