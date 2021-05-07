using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(AudioSource))]
public class loadSoundConsigna : MonoBehaviour {
	AudioSource audioData;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadAudioData(){
		audioData = GetComponent<AudioSource> ();
		audioData.Play ();
	}


}
