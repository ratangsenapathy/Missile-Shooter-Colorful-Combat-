using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "Score: " + ScoreManager.score;
	}
		
	public void GoToMainMenu()
	{
		SceneManager.LoadScene ("MainMenuScene", LoadSceneMode.Single);
	}
}
