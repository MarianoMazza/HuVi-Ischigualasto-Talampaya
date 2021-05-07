using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class BubbleDialog : MonoBehaviour {
	public Canvas dialogo;
	public GameObject contexto;
	public GameObject avatar;
	AudioSource audioData;
	AudioSource audioDataTotem;

	public GameObject player;
	public GameObject explotion;
	protected int salio = 0;
	public GameObject avisoDescubrioPista;
	public bool habilitarTotemI;
	public GameObject rocasTotemI;
	public bool habilitarTotemII;
	public GameObject rocasTotemII;
	public bool habilitarTotemIII;
	public GameObject rocasTotemIII;
	public GameObject explosionRocas;

	// Use this for initialization
	void Start () {
		

		if (dialogo != null) {
			dialogo.enabled = false;
		}
		if (contexto != null) {
			contexto.SetActive (false);
		}



	}

	public void outOption(){
		salio = 1;
	}

	//Manejo de diálogos
	void Update () {
		
	}

	public void activeObject(){
		contexto.SetActive (true);
		audioData = transform.GetComponent<AudioSource> ();
		audioData.Play ();
	}
		
	public void activeBubbleDialog(){
		    
		if (salio == 0) {
			salio = 1;


			if (avatar != null) {
				
				avatar.SetActive (true);
				explotion.SetActive (true);
				if (avatar.transform.GetComponent<AudioSource> () != null) {
					avatar.transform.GetComponent<AudioSource> ().Play ();
				}
				StartCoroutine (delay (3f));

			} else {
				/*dialogo.enabled = true;*/
				audioData = dialogo.transform.GetComponent<AudioSource> ();
				audioData.Play ();
				//this.desactivarContexto ();
				StartCoroutine (delay (3f));

			}
		}

	}

	private void desactivarContexto(){
		if (contexto != null) {
			contexto.gameObject.SetActive(false);

		}
	}

	IEnumerator delay(float time)
	{

		dialogo.enabled = true;
		if (avisoDescubrioPista != null) {
			avisoDescubrioPista.SetActive (true);
		}

		if (habilitarTotemI) {
			rocasTotemI.SetActive(false);
			explosionRocas.SetActive(true);
			explosionRocas.transform.GetComponent<AudioSource> ().Play ();
		}
		if (habilitarTotemII) {
			rocasTotemII.SetActive(false);
			explosionRocas.SetActive(true);
			explosionRocas.transform.GetComponent<AudioSource> ().Play ();
		}
		if (habilitarTotemIII) {
			rocasTotemIII.SetActive(false);
			explosionRocas.SetActive(true);
			explosionRocas.transform.GetComponent<AudioSource> ().Play ();
		}


		yield return new WaitForSeconds (time);
		if (avisoDescubrioPista != null) {
			avisoDescubrioPista.SetActive (false);
		}

		if (player != null) {
			explotion.SetActive (false);
			player.GetComponent<AudioSource> ().volume = 0.1f;
			audioData = dialogo.transform.GetComponent<AudioSource> ();
			audioData.Play ();
		}

		this.desactivarContexto ();
		yield return new WaitForSeconds (12f);
		player.GetComponent<AudioSource> ().volume = 1f;

	}



}
