using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rb2d;
	public float speed;
	public GameObject ammo;
	//public Transform missile;
//	public Camera camera;
	void Start()
	{	
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
		//Instantiate (missile, new Vector3 (5, 5, 0), Quaternion.identity);
	}

	void Update()
	{
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp(pos.x,0.025f,0.975f);
		pos.y = Mathf.Clamp(pos.y,0.05f,0.97f);

		transform.position = Camera.main.ViewportToWorldPoint(pos);
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);

		if (Input.GetMouseButtonDown(0)) 
		{
			Instantiate (ammo,transform.position,transform.rotation);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 movementDir = Vector3.Normalize(mousePos - transform.position);
		Vector2 movement = new Vector2 (movementDir.x, movementDir.y);
		movement.Normalize ();
		if (Mathf.Abs (mousePos.x - transform.position.x) < 0.2f && Mathf.Abs (mousePos.y - transform.position.y) < 0.2f)
			rb2d.velocity = new Vector2 (0.0f, 0.0f);
		else
			rb2d.velocity = (movement * speed);
	}
}
