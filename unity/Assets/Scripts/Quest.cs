using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Quest : MonoBehaviour {

	public Text timerText;
	private float timer = 90;
	public GameObject[] waypoints;
	TimeSpan ts;

	void Awake(){

		//make waypoints here
		//start waypoint
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		ts = TimeSpan.FromSeconds (timer);

		timerText.text = ts.ToString();
	}
}
