using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class deathMenu: MonoBehaviour {


	public void gameRestart() {

		SceneManager.LoadScene ("Endless");
	}

	public void QuitMainMenu () {

		SceneManager.LoadScene ("Main Menu");
	}
}
