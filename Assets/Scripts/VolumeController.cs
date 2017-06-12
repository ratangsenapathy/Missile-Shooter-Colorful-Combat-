using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(SoundManager.soundsOn)
			GetComponent<AudioSource> ().volume =1.0f;
		else
			GetComponent<AudioSource> ().volume =0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
