using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoFire : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rb2d;
	public float speed;
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.velocity = transform.up*speed;
	}
	
	void Update()
	{
		Vector3 point = Camera.main.WorldToViewportPoint (transform.position);
		if (point.x < -0.5f || point.x > 1.5 || point.y < -0.5f || point.y > 1.5)
			Destroy (this.gameObject);
	}
}
