using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour {

	// Use this for initialization
	public static bool soundsOn = true;

	void Start()
	{	
		int storage = PlayerPrefs.GetInt ("Sound", 1);
		soundsOn = storage == 1 ? true : false;
		if(soundsOn)
			transform.GetChild(0).GetComponent<Text>().text = "Sounds: On";
		else
			transform.GetChild(0).GetComponent<Text>().text = "Sounds: Off";
	}
	public void ToggleSound()
	{
		soundsOn = !soundsOn;
		if(soundsOn)
			transform.GetChild(0).GetComponent<Text>().text = "Sounds: On";
		else
			transform.GetChild(0).GetComponent<Text>().text = "Sounds: Off";
		PlayerPrefs.SetInt("Sound", (int) (soundsOn?1:0));
	}
}
