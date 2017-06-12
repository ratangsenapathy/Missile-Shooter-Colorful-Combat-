using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileController : MonoBehaviour {

	// Use this for initialization

	public float speed;
	private Rigidbody2D rb2d;
	private Transform player;
	public GameObject explosion;
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("fighter-jet")!=null?GameObject.Find ("fighter-jet").transform:null;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector3 movementDir = new Vector3 ((player.position.x - transform.position.x), (player.position.y - transform.position.y),0.0f);
			Vector2 movement = new Vector2 (movementDir.x, movementDir.y);
			movement.Normalize ();
			rb2d.velocity = (movement * speed);

			transform.rotation = Quaternion.LookRotation (Vector3.forward,transform.position - player.position);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "fighter-jet" || other.name.Contains("jet-missile")) {
			GameObject explosive = Instantiate (explosion, other.transform.position, Quaternion.identity);
			if (other.name != "fighter-jet") {
				explosive.transform.localScale = new Vector3 (0.5f, 0.5f, 1.0f);
				if(this.name.Contains("Red"))
					ScoreManager.score += 10;
				else if(this.name.Contains("Purple"))
					ScoreManager.score += 15;
				else
					ScoreManager.score += 20;
			}
			if (other.name == "fighter-jet") {
				Destroy (other.gameObject);
				Destroy (this.gameObject);
				//Invoke ("GoToGameOver", 1.0f);
			} else {
				Destroy (other.gameObject);
				Destroy (this.gameObject);
			}
		}

	}

	void GoToGameOver()
	{   
		SceneManager.LoadScene ("GameOverScene", LoadSceneMode.Single);
		Destroy (this.gameObject);
	}
}
