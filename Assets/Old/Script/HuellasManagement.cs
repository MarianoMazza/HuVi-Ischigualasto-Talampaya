using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HuellasManagement: MonoBehaviour {
	private int salio;
	public Canvas dialogo;
	public GameObject starts;
	public GameObject huella;
	public GameObject huellaVerde;
	public GameObject huellaDorada;
	// Use this for initialization
	void Start () {
		dialogo.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void outOption(){
		salio = 1;
	}


	public void nextTotem(){
		salio = 0;
		dialogo.enabled = true;
	    AudioSource audioData = dialogo.GetComponent<AudioSource> ();


			if (PlayerPrefs.GetString ("UsoPista")=="1") {
				//huella.SetActive (false);
				huellaVerde.SetActive (true);


			} else {
				//huella.SetActive (false);
				huellaDorada.SetActive (true);
			
			}
		starts.SetActive (true);
		audioData.Play ();
		StartCoroutine(delay(2f, "next"));	

	}

	public void idemTotem(){
		
		salio = 0;
		dialogo.enabled = true;
		AudioSource audioData = dialogo.GetComponent<AudioSource> ();
		audioData.Play ();
		StartCoroutine (delay (2f, "idem"));
	}

	IEnumerator delay(float time, string accion)
	{
		yield return new WaitForSeconds(time);


			switch (accion)
			{
			case "next":
				{
				    //Codigo solo para el prototipo
					/*PlayerPrefs.SetString ("Desafio","3");
				    PlayerPrefs.SetInt ("eligioOpcion", 3);
				    PlayerPrefs.SetInt ("avanzoTotemIII", 1);
				    PlayerPrefs.SetInt ("totemHabilitado", 0);
				    PlayerPrefs.SetInt ("EntradaCataratas",1);
				    SceneManager.LoadScene ("VideoPlayCataratas");*/
					Debug.Log ("llegó a seleccionar la opcioón");

					if (PlayerPrefs.GetString ("Desafio") == "1") {
					    Debug.Log ("Descubriendo el parque");
					    PlayerPrefs.SetInt ("eligioOpcion", 1);
					    PlayerPrefs.SetInt ("avanzoTotemI", 1);
					    PlayerPrefs.SetInt ("totemHabilitado", 1);
					    PlayerPrefs.SetInt ("totemIHabilitado", 0);
					    SceneManager.LoadSceneAsync ("DescubriendoParque");
					break;
						
					}
					if (PlayerPrefs.GetString ("Desafio") == "2") {
						Debug.Log ("Descubriendo el parque");
						PlayerPrefs.SetInt ("eligioOpcion", 2);
					   //poner 2, cuando se haga la pasarlla 3
						PlayerPrefs.SetInt ("avanzoTotemII", 1);
					    PlayerPrefs.SetInt ("totemHabilitado", 1);
					    PlayerPrefs.SetInt ("totemIHabilitado", 0);
						SceneManager.LoadSceneAsync  ("DescubriendoParque");
					break;
					}
					if (PlayerPrefs.GetString ("Desafio") == "3") {
						Debug.Log ("Descubriendo el parque");
						PlayerPrefs.SetInt ("eligioOpcion", 3);
					    PlayerPrefs.SetInt ("avanzoTotemIII", 1);
					    PlayerPrefs.SetInt ("EntradaCataratas", 1);
						PlayerPrefs.SetInt ("totemHabilitado", 0);
						SceneManager.LoadSceneAsync  ("DescubriendoParque");
					break;   
					}


              
				}break;
			case "idem":
				{
					if (PlayerPrefs.GetString ("Desafio") == "1") {
						PlayerPrefs.SetInt ("eligioOpcion", 1);
						PlayerPrefs.SetInt ("avanzoTotemI", -1);
						PlayerPrefs.SetInt ("totemHabilitado", 1);
						PlayerPrefs.SetInt ("totemIHabilitado", 0);
						SceneManager.LoadScene ("DescubriendoParque");
						break;
					}
					if (PlayerPrefs.GetString ("Desafio") == "2") {
						Debug.Log ("Descubriendo el parque");
						PlayerPrefs.SetInt ("eligioOpcion", 1);
						PlayerPrefs.SetInt ("avanzoTotemII", -1);
					    PlayerPrefs.SetInt ("totemHabilitado", 1);
					    PlayerPrefs.SetInt ("totemIHabilitado", 0);
						SceneManager.LoadScene ("DescubriendoParque");
					break;
					}
					if (PlayerPrefs.GetString ("Desafio") == "3") {
						Debug.Log ("Descubriendo el parque");
						PlayerPrefs.SetInt ("eligioOpcion", 1);
						PlayerPrefs.SetInt ("avanzoTotemIII", -1);
					    PlayerPrefs.SetInt ("totemHabilitado", 1);
					    PlayerPrefs.SetInt ("totemIHabilitado", 0);
						SceneManager.LoadScene ("DescubriendoParque");
					break;
					}
				}break;
			default:
				// You can use the default case.
				break;
			}

		}


}
