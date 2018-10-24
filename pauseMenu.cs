using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

	public GameObject pauseMenuPicker;

	public void pauseGame () {
		if (Time.timeScale == 1) {
			pauseMenuPicker.gameObject.SetActive (true);
			Time.timeScale = 0;
		} else if (Time.timeScale == 0) {
			pauseMenuPicker.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
