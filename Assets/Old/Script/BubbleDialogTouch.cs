using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(AudioSource))]
public class BubbleDialogTouch : MonoBehaviour {
	/*public Canvas dialogoI;
	public Canvas dialogII;
	public Canvas dialogIII;*/
	public Canvas dialogo;
	private string desafio;
	public Transform player;
	public float position;
	AudioSource audioData;
	int salio = 0;
	int activeSound = 0;
	// Use this for initialization
	void Start () {
		dialogo.enabled = false;
		//StartCoroutine (delay (20f));
	}

	//Habilita el dialogo por 10'' luego lo deshabilita
	public void enabledDialogPortal() {
		salio = 0;
		StartCoroutine (enabledDialog (2f));

	}


	IEnumerator delay(float time)
	{
		yield return new WaitForSeconds(time);
		dialogo.enabled = false;
		activeSound = 0;


	}


	IEnumerator enabledDialog(float time)
	{

		    yield return new WaitForSeconds(time);
		if ((salio == 0) && (activeSound == 0)) {
			activeSound = 1;
			dialogo.enabled = true;
			audioData = GetComponent<AudioSource> ();
			player.GetComponent<AudioSource> ().volume = 0.1f;
			audioData.Play ();
			StartCoroutine (delay (10f));
		}

	}




	public void outOption(){
		salio = 1;
	}

	public void enabledDialog () {

		if ((player != null) && (player.position.x >= position)) {
			dialogo.enabled = true;
			audioData = GetComponent<AudioSource> ();
			audioData.Play ();
			//Habilitar audio
			player.GetComponent<AudioSource> ().volume = 0.1f;
			StartCoroutine (delay (30f));
		} else {
			//no depende de la posicion del jugador
			dialogo.enabled = true;
			audioData = GetComponent<AudioSource> ();
			audioData.Play ();
			//Habilitar audio
			player.GetComponent<AudioSource> ().volume = 0.1f;
			StartCoroutine (delay (30f));
		}


	}





}
