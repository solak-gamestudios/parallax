﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	public Text timerLabel;

	private float time;

	void Update() {
		
		time += Time.deltaTime;

		float minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		minutes = Mathf.Floor(minutes);
		float seconds = time % 60;//Use the euclidean division for the seconds.
		//var fraction = (time * 100) % 100;

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
	}
}