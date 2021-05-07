using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent (typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour {
	public Transform player;
	public string eje;

	// Indicar hacia donde se tiene q desplazar el jugador
	// 1 => Senialetica
	// 2 => Portal cataratas

	Vector3 playerVector;

	public float velocidad;

	//Variable para manejar la opción a través del time
	protected int salio = 0;
	void Start () {
		Debug.Log(PlayerPrefs.GetInt ("avanzoTotemI"));

		    //Esto maneja la posición del personaje en los distintos terrenos
		//Debug.Log("Avanzo totem1" + PlayerPrefs.GetInt ("avanzoTotemI"));
		//Debug.Log("Avanzo totem1" + PlayerPrefs.GetInt ("eligioOpcion"));
	


		if (PlayerPrefs.GetString ("Desafio") == "1") {
			
			
			if (PlayerPrefs.GetInt ("avanzoTotemI") == 1) {
				player.rotation = new Quaternion (0f, 0f, 0f, 0f);
				player.position = new Vector3 (369f, 7f, 39.46f);
				PlayerPrefs.SetInt ("avanzoTotemI", 1);
			} else {
				if (PlayerPrefs.GetInt ("avanzoTotemI") == -1) {
					player.position = new Vector3 (60, 7, 38.64f);
					PlayerPrefs.SetInt ("avanzoTotemI", 0);
				}
			}

		} else {
			if (PlayerPrefs.GetString ("Desafio") == "2") {
				
				if (PlayerPrefs.GetInt ("avanzoTotemII") == 1) {
					//Reproducimos el audio de cataratas
					player.GetComponent<AudioSource> ().Stop ();

					this.transform.GetComponent<AudioSource> ().Play ();

					player.rotation = new Quaternion (0f, 0f, 0f, 0f);
					player.Rotate (Vector3.up * -90);
					player.position = new Vector3 (330.5f, 7, 457f);
					PlayerPrefs.SetInt ("avanzoTotemI", 0);
				} else {
					if (PlayerPrefs.GetInt ("avanzoTotemII") == -1) {
						player.rotation = new Quaternion (0f, 0f, 0f, 0f);
						player.position = new Vector3 (369f, 7f, 39.46f);
						PlayerPrefs.SetInt ("avanzoTotemI", 0);
					}
				}

				//Para el caso de ver el  video de premio
				if(PlayerPrefs.GetInt ("VideoPremioI")==1){
					PlayerPrefs.SetInt ("VideoPremioI",0);
					player.rotation = new Quaternion (0f, 0f, 0f, 0f);
					player.position = new Vector3 (369.6f, 7f, 39.46f);
				}



				
			} else {
				if (PlayerPrefs.GetString ("Desafio") == "3") {

					if (PlayerPrefs.GetInt ("avanzoTotemIII") == 1) {

					    //Reproducimos el audio de cataratas
						player.GetComponent<AudioSource> ().Stop ();

						this.transform.GetComponent<AudioSource> ().Play ();

						player.rotation = new Quaternion (0f, 0f, 0f, 0f);
						player.Rotate (Vector3.up * 180);


						//Posiciones Definidas para el manejo de la vuelta de los VIDEOS
						if (PlayerPrefs.GetInt ("EntradaCataratas") == 1) {
							player.position = new Vector3 (125f, 7, 451f);
						} else {
							if (PlayerPrefs.GetInt ("EntradaCataratas") == 2) {
								
								player.position = new Vector3 (125f, 7, 349f);
							} else {
								if (PlayerPrefs.GetInt ("EntradaCataratas") == 3) {
									player.position = new Vector3 (125f, 7, 262f);
								} else {
									player.position = new Vector3 (125f, 7, 451f);
								}
							}
						}

					


						//PlayerPrefs.SetInt ("avanzoTotemI", 0);
					} else {
						if (PlayerPrefs.GetInt ("avanzoTotemIII") == -1) {
							//Reproducimos el audio de cataratas
							player.GetComponent<AudioSource> ().Stop ();

							this.transform.GetComponent<AudioSource> ().Play ();
							player.rotation = new Quaternion (0f, 0f, 0f, 0f);
							player.Rotate (Vector3.up * -90);
							player.position = new Vector3 (330f, 7, 457f);

						}
						//Para el caso de ver el  video de premio
						if(PlayerPrefs.GetInt ("VideoPremioII")==1){
							PlayerPrefs.SetInt ("VideoPremioII",0);
							player.rotation = new Quaternion (0f, 0f, 0f, 0f);
							player.Rotate (Vector3.up * -90);
							player.position = new Vector3 (330f, 7, 457f);
						}
					}
			
				} else {
					if (PlayerPrefs.GetInt ("vuelveAEArgentina") == 1) {//vuelve al terreno "EArgentina"
						player.rotation = new Quaternion (0f, 0f, 0f, 0f);
						player.Rotate (Vector3.up * 60);

						//791f, 36f, 258f
						player.position = new Vector3 (766f, 38f, 246f);

					} else {
						//CuidandoLaBiodiversidad
						if (PlayerPrefs.GetInt ("CuidandoLaViodiversidad") == 1) {
							//Eje cuidando la biodiversidad
							player.rotation = new Quaternion (0f, 0f, 0f, 0f);
							player.Rotate (Vector3.up * 90);
							player.position = new Vector3 (2.5f, 14f, 243.2f);
						}

					}
				}
			}
		}

	}


	void Update () {
		player.transform.Translate(playerVector);

	}


	public void movIn(float limite){
		
		var ejeActual = eje;
			///-------------


		switch (ejeActual)
		{
		case "z":
			{
				Debug.LogError(Camera.main.transform.eulerAngles.y);
				if((Camera.main.transform.eulerAngles.y>=0f && Camera.main.transform.eulerAngles.y<90)||(Camera.main.transform.eulerAngles.y>270f && Camera.main.transform.eulerAngles.y<360)) {
					playerVector = Vector3.forward * velocidad;	
				} else {
					playerVector = Vector3.back * velocidad;
				}

				break;
			}
		
		case "z-b": //Entrada portal de cataratas
			{

				Debug.LogError(Camera.main.transform.eulerAngles.y);
				if((Camera.main.transform.eulerAngles.y>=0f && Camera.main.transform.eulerAngles.y<128)||(Camera.main.transform.eulerAngles.y>353f && Camera.main.transform.eulerAngles.y<360)) {
					playerVector = Vector3.forward * velocidad;	
				} else {
					playerVector = Vector3.back * velocidad;
				}
					
				break;
			}

		case "x":
			{
				Debug.LogError(Camera.main.transform.eulerAngles.y);
				if(Camera.main.transform.eulerAngles.y>=14 && Camera.main.transform.eulerAngles.y<=180){
						Debug.Log ("actualiza");
						playerVector = Vector3.forward * velocidad;
						//playerVector += new Vector3 (velocidad, 0, 0);
					} else {
						//Para volver
						playerVector = Vector3.back * velocidad;
					}
					player.transform.Translate(playerVector);

				break;
			}
		case "z-d":
			{

				   Debug.LogError(Camera.main.transform.eulerAngles.y);
				   if((Camera.main.transform.eulerAngles.y>=0f && Camera.main.transform.eulerAngles.y<90)||(Camera.main.transform.eulerAngles.y>270f && Camera.main.transform.eulerAngles.y<360)) {
						Debug.Log ("actualiza");
						playerVector = Vector3.forward * velocidad;
						//playerVector += new Vector3 (velocidad, 0, 0);
					} else {
						//Para volver
						playerVector = Vector3.back * velocidad;
					}
					player.transform.Translate(playerVector);

				break;
			}
		case "z-r":
			{
				
				Debug.LogError(Camera.main.transform.eulerAngles.y);
				if((Camera.main.transform.eulerAngles.y>=0f && Camera.main.transform.eulerAngles.y<90)||(Camera.main.transform.eulerAngles.y>270f && Camera.main.transform.eulerAngles.y<360)) {
					playerVector = Vector3.back * velocidad;	
				} else {
					playerVector = Vector3.forward * velocidad;
				}
				break;
			}
		case "x-r":
			{

				//Avanzar
				Debug.LogError(Camera.main.transform.eulerAngles.y);
				if(Camera.main.transform.eulerAngles.y>=14 && Camera.main.transform.eulerAngles.y<=180){
					Debug.Log ("actualiza");
					playerVector = Vector3.back * velocidad;
					//playerVector += new Vector3 (velocidad, 0, 0);
				} else {
					//Para volver
					playerVector = Vector3.forward * velocidad;
				}
				player.transform.Translate(playerVector);

				break;

			}
		default:
			// You can use the default case.
			break;
		}




	}
	public void movOut(){
		playerVector = new Vector3 (0,0,0);
		salio = 1;
		Debug.Log("salio");
	}


	//Posiciona al jugador en un punto determinado
	public void postIn(){
		salio = 0;
		StartCoroutine(delay(2f,"positionIn"));

	}


	public IEnumerator delay(float time, string accion)
	{
		print(Time.time);
		yield return new WaitForSeconds(time);
		if (salio == 0) {

			switch (accion)
			{
			case "positionIn":
				{
					//Potal cataratas
					//player.rotation = new Quaternion (0f, 180f, 0f, 72f);
					//player.position = new Vector3 (745f, 43f, 246f);
					player.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
					player.transform.Rotate (Vector3.up * 60);
					player.transform.position = new Vector3 (766f, 38f, 246f);
					PlayerPrefs.SetString("Desafio", "EArgentina");
					break;
				}
			default:
				// You can use the default case.
				break;
			}
				
		}

	}
}
