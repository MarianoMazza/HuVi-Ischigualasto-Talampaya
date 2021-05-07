using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class GameObjectManager : MonoBehaviour {
	protected int salio = 0;
	public GameObject doorL;
	public GameObject doorR;
	public GameObject key;
	public GameObject subtitulo;
	AudioSource audioData;
	Vector3 posicionRotacionL;
	Vector3 posicionRotacionR;
	public GameObject holograma;
	public GameObject cartelBobo;
	public GameObject gema; 
	public GameObject cartelMadera;
	public GameObject logo;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("Desafio") == "EArgentina") {
			if (PlayerPrefs.GetInt ("Action") == 1) {
				
				while (doorL.transform.position.x >792.683f) {
					//Debug.Log("la door izquierda tiene una pos de:" + doorL.transform.position.x );
					doorL.transform.Translate (Vector3.left* 0.2f);
					doorR.transform.Translate(Vector3.right* 0.2f);
					key.SetActive (false);
				}
				holograma.SetActive (true);
				cartelBobo.SetActive (false);
				gema.SetActive (false);
		        
				while (cartelMadera.transform.position.y < 37.00093f) {
					cartelMadera.transform.Translate ( Vector3.up * 0.8f);
				}
				logo.SetActive (true);
			
			
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("la door izquierda tiene una pos de:" + doorL.transform.position.x );
		if (doorL.transform.position.x > 792.683f) {
			doorL.transform.Translate (posicionRotacionL);
			doorR.transform.Translate(posicionRotacionR);
		}


	}

	public void openDoord(){
		salio = 0;
		subtitulo.SetActive (true);
		audioData = subtitulo.transform.GetComponent<AudioSource> ();
		audioData.Play ();
		StartCoroutine(delaySubtittle(2f));

		StartCoroutine(delay(2f, "openDoor", null));


	}
	IEnumerator delaySubtittle(float time)
	{
		print (Time.time);
		yield return new WaitForSeconds (time);
		subtitulo.SetActive (false);
	}

	public void pointerExit(){
		salio = 1;
		posicionRotacionL = new Vector3();
		posicionRotacionR=  new Vector3();
	}

	IEnumerator delay(float time, string accion, string nameSecene)
	{
		print(Time.time);
		yield return new WaitForSeconds(time);
		if (salio == 0) {
			switch (accion)
			{
			case "openDoor":
				{
					

					//doorL.transform.position += 	new Vector3 (-0.00398f, 0, 0.0017f);
					//doorL.transform.rotation = new Quaternion (0f, 0f, 0f, 77f);
					posicionRotacionL = Vector3.left* 0.2f;
					posicionRotacionR = Vector3.right* 0.2f;



					//doorR.transform.position += 	new Vector3 (-0.00013f, 0, 0.0038f);
					//doorR.transform.rotation = new Quaternion (0f, -77f, 0f, 0f);




					key.gameObject.SetActive(false);
					break;
				}
			default:
				// You can use the default case.
				break;
			}

		}


	}

}
