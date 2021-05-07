using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class PlayerMovementIntroGta : MonoBehaviour {
	public AudioClip audioData;
	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetInt ("avanzoTotemIII")== 1) {
			//player.transform.GetComponent<AudioSource>().clip= audioData;

			//player.transform.GetComponent<AudioSource> ().Play ();	//;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
