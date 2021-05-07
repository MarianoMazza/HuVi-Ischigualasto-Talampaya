using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(AudioSource))]

public class ActiveDesafio : MonoBehaviour {
	public GameObject objects;

	public GameObject question;

	AudioSource audioData;
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void activeObjects(){
		StartCoroutine (enabledObject (0.5f));



	}


	IEnumerator enabledObject(float time)
	{

		yield return new WaitForSeconds(time);
		audioData = GetComponent<AudioSource> ();
		audioData.Play ();
		objects.SetActive (true);
	
		question.SetActive (false);

	}


}
