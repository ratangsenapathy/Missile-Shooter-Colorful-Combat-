using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;        // The player's score.


	private Text text;                      // Reference to the Text component.
	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.
		score = 0;
		Invoke ("IncrementScore", 1.0f);
	}

	void IncrementScore()
	{
		score++;
		Invoke ("IncrementScore", 1.0f);
	}

	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Score: " + score;
	}
}
