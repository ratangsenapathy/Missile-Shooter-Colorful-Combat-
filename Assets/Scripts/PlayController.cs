using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayController : MonoBehaviour {

	public void GoToPlayArea()
	{

		SceneManager.LoadScene ("GameScene", LoadSceneMode.Single);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit ();
		}

	}
}
