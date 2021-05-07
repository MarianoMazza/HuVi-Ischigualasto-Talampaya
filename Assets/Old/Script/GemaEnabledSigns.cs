using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class GemaEnabledSigns : MonoBehaviour {
	public GameObject gema;
	public GameObject cartel;
	public GameObject cartelMadera;
	public GameObject holograma;
	public GameObject logo;
	AudioSource audioData;
	Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cartelMadera.transform.position.y < 37.00093f) {
			cartelMadera.transform.Translate (position);
		}
	}

	public void enabledCartelHologram(){
		audioData = transform.GetComponent<AudioSource> ();
		audioData.Play ();
		cartel.SetActive (false);
		holograma.SetActive (true);

		position = Vector3.up * 0.8f;

		StartCoroutine (delay (0.5f));

	}

	IEnumerator delay(float time)
	{
		yield return new WaitForSeconds(time);
		if (cartelMadera.transform.position.y >= 37.00093f) {
			logo.SetActive (true);
			gema.SetActive (false);
		}
	}
}

	
