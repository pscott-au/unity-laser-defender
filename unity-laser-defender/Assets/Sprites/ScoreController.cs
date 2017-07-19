using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public static int score = 0;
	private Text myText ;
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text> ();
		ResetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void ResetScore() {
		score = 0;
		// myText.text = score.ToString ();
	}

	public void AddScore(int points) {
		score += points;
		myText.text = score.ToString ();
	}
}
