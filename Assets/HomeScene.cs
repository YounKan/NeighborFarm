using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour {
	public GameObject bed;
	public GameObject bg;
	public GameObject sleep;

	public static int minute;
	public static int sec;
	private static float timer;

	public  bool isStart = false;

	public Text showTime;

	void OnMouseDown (){
		if (this.gameObject.name == "bed") {
			isStart = true;
			sleep.SetActive (true);
			bg.SetActive (false);

		}
	}

	// Update is called once per frame
	void Update () {
		if (isStart) {
			if (sec != 30) {
				timer += Time.deltaTime;
				minute = (int)(timer / 60);
				sec = (int)(timer % 60);
				showTime.text = String.Format ("Now .. you sleep." + "{00:00}:{01:00}", minute, sec);
			} else {
				userDetail.energy += 30;
				sleep.SetActive (false);
				bg.SetActive (true);
				isStart = false;
				timer = 0;
				minute = 0;
				sec = 0;
		
			}

		} else {
			showTime.text = "Do you want to sleep ?";
		}
		
	}
}
