using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MissileGenerator : MonoBehaviour {

	// Use this for initialization

	public GameObject[] missiles;
	private Transform player;
	void Start () {
		player = GameObject.Find ("fighter-jet")!=null?GameObject.Find ("fighter-jet").transform:null;
		Invoke ("InstantiateMissile",0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			Invoke ("GoToGameOver", 1.0f);
		if (Input.GetKey(KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenuScene", LoadSceneMode.Single);
		}
	}

	void InstantiateMissile()
	{
		int noOfMissiles = Random.Range (1, 2);
		for (int i = 0; i < noOfMissiles; i++) {
			int randomMissile = Random.Range (0, 3);
			float spawnPointX = Random.Range (-1.1f, 1.1f);
			float spawnPointY = 0.0f;
			if (spawnPointX < 0.0f || spawnPointX > 1.0f) {
				spawnPointY = Random.Range (-1.1f, 1.1f);
			} else
				spawnPointY = 1.1f;
			Vector3 spawnPoint = new Vector3 (spawnPointX,spawnPointY,0.0f);
			spawnPoint = Camera.main.ViewportToWorldPoint (spawnPoint);
			spawnPoint.z = 0.0f;
			Instantiate (missiles[randomMissile], spawnPoint, Quaternion.identity);
			float randomTime = Random.Range(1, 3);
			Invoke ("InstantiateMissile", randomTime);
		}
	}

	void GoToGameOver()
	{   
		SceneManager.LoadScene ("GameOverScene", LoadSceneMode.Single);
		Destroy (this.gameObject);
	}
}
