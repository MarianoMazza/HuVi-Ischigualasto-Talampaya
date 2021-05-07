using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class DelayedStart : MonoBehaviour {
	public GameObject tresDosUno;
	public ActiveDesafio activar;
	AudioSource audioData;
	// Use this for initialization
	void Start () {
		audioData = GetComponent<AudioSource> ();
		audioData.Play ();
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}



IEnumerator delay()
{
		Time.timeScale = 0;
		float pauseTime = Time.realtimeSinceStartup + 5f;
		while (Time.realtimeSinceStartup < pauseTime) {
			yield return 0;
		}
		tresDosUno.gameObject.SetActive (false);
		//audioData.Stop ();
		activar.activeObjects ();
		Time.timeScale = 1;
	
}
}
