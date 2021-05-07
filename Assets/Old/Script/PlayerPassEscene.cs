using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(AudioSource))]
public class PlayerPassEscene : PlayerMovement {
	public Canvas dialogo;
	public GameObject contextoDesafio;
	public GameObject avatar;

	public GameObject volver;
	public GameObject cartelConfirmacionVolver;
	/***elementos q se activaran al caragar la ecena***/
	public GameObject progress;

	public BarProgress barProgress;
	public GameObject subtitulo;
	AudioSource audioData;

	int activeAudio = 0;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void outOption(){
		salio = 1;
	}

	public void returnTo(){
		salio = 0;
		subtitulo.SetActive (true);
		audioData = subtitulo.transform.GetComponent<AudioSource> ();
		audioData.Play ();
		StartCoroutine(delaySubtittle(2f));
		StartCoroutine(delay(2f,"returnTo"));

	}
	IEnumerator delaySubtittle(float time)
	{
		print (Time.time);
		yield return new WaitForSeconds (time);
		subtitulo.SetActive (false);
	}
	public void passTo(string escene){
		salio = 0;

			if (escene == "DescubriendoParque") {//Para q no espere en el primer paso a la escena "DescubriendoParque"
				if (activeAudio == 0) {
					activeAudio = 1;
					StartCoroutine (delayAudioOpcionesPortal (1f));
				}
				StartCoroutine (delay (3f, escene));
			
			} else {
			//se debera  deshabilitar las demas esferas para manejar el acceso a los distintos escenarios
				if (escene == "CuidandoLaBiodiversidad") {//Para q no espere en el primer paso a la escena "DescubriendoParque"
					if (activeAudio == 0) {
						activeAudio = 1;
						StartCoroutine (delayAudioOpcionesPortal (1f));
					}
					StartCoroutine (delay (3f, escene));
			
				} else {
					if (escene == "FLORA") {//Para q no espere en el primer paso a la escena "DescubriendoParque"
						if (activeAudio == 0) {
							activeAudio = 1;
							StartCoroutine (delayAudioOpcionesPortal (1f));
						}
						//StartCoroutine (delay (3f, escene));

					} else {
						if (subtitulo != null) {
							subtitulo.SetActive (true);
							audioData = subtitulo.transform.GetComponent<AudioSource> ();
							audioData.Play ();
						    //Para desactivar el subtitulo automaticamente
							StartCoroutine (delaySubtittle (2f));

						}
						StartCoroutine (delay (2f, escene));
					}

				}

			}

	}


	IEnumerator delayAudioOpcionesPortal(float time)
	{
		AudioSource audioData = this.transform.GetComponent<AudioSource> ();
		player.GetComponent<AudioSource> ().volume = 0.1f;
		audioData.Play ();
		yield return new WaitForSeconds (time);
		activeAudio = 0;
	}

	/// <summary>
	/// Ups to desafio: se eleva la superficie y el jugador para resolver el desafio
	/// </summary>
	public void upToDesafio(string escene){

	      if (PlayerPrefs.GetInt ("totemHabilitado") == 1) {//El tótem está vigente para su activación
			dialogo.enabled = true;
			AudioSource audioData = dialogo.GetComponent<AudioSource> ();
			audioData.Play ();
		    salio = 0;
			PlayerPrefs.SetInt("totemHabilitado", 0);
			StartCoroutine (delay (4f, escene));

	}

	}



	public void backTo(string escene){
		salio = 0;
		StartCoroutine(delay(2f,escene));
	}
	IEnumerator delay(float time, string accion)
	{
		print(Time.time);
		yield return new WaitForSeconds(time);
			switch (accion)
			{
			case "positionIn":
				{
				if (salio == 0) {
					//Potal cataratas
					//player.rotation = new Quaternion (0f, 62.54801f, 0f, 72f);
					//player.position = new Vector3 (780f, 135f, 1410f);
					player.rotation = new Quaternion (0f, 0f, 0f, 0f);
					player.Rotate (Vector3.up * 60);
					player.position = new Vector3 (745f, 40f, 234f);
				}
					break;
				}
			case "returnTo":
			{
				if (salio == 0) {
					cartelConfirmacionVolver.SetActive (true);
				}
				break;
			}
			case "DescubriendoParque":
				{
					
				if (salio == 0 && PlayerPrefs.GetInt ("avanzo_eje") ==0) {
					
					progress.SetActive (true);
					//Potal cataratas
					PlayerPrefs.SetString ("Desafio", "DescubriendoParque");
					PlayerPrefs.SetInt ("Action", 0);
					PlayerPrefs.SetInt ("eligioOpcion", 0);
					PlayerPrefs.SetInt ("avanzoTotemI", 0);
					PlayerPrefs.SetInt ("totemHabilitado", 1);
					PlayerPrefs.SetInt ("totemIHabilitado", 0);
					PlayerPrefs.SetInt ("vuelveAEArgentina", 0);
					PlayerPrefs.SetInt ("EntradaCataratas", 0);


					barProgress.OnChange (this.OnBarProgressChange);
					barProgress.OnDone (this.OnBarProgressDone);
					AsyncOperation operation = SceneManager.LoadSceneAsync ("DescubriendoParque");
					//operation.allowSceneActivation = false;

					while (!operation.isDone) {
						barProgress.SetValue (operation.progress);
						yield return null;
						}

				}
					break;
				}
		case "CuidandoLaBiodiversidad":
			{
				//El jugador avanzó el eje1 = > puede acceder al eje2
				if (salio == 0 && PlayerPrefs.GetInt ("avanzo_eje") == 1) {
					//Potal cataratas
					PlayerPrefs.SetString ("Desafio", "CuidandoLaBiodiversidad");
					/*PlayerPrefs.SetInt ("Action", 0);
					PlayerPrefs.SetInt ("eligioOpcion", 0);
					PlayerPrefs.SetInt ("avanzoTotemI", 0);
					PlayerPrefs.SetInt ("totemHabilitado", 1);
					PlayerPrefs.SetInt ("totemIHabilitado", 0);
					PlayerPrefs.SetInt ("EntradaCataratas", 0);*/
					PlayerPrefs.SetInt ("vuelveAEArgentina", 0);
					SceneManager.LoadScene ("CuidandoLaBiodiversidad");
				}
				break;
			}
		case "FLORA":
			{

				if (salio == 0) {
					///implementar escena
				}
				break;
			}
			case "VolverADescubriendoParque":
				{

				if (salio == 0) {
					//Potal cataratas
					PlayerPrefs.SetInt ("eligioOpcion", 0);
					PlayerPrefs.SetInt ("avanzoTotemI", 0);
					PlayerPrefs.SetInt ("totemHabilitado", 0);
					PlayerPrefs.SetInt ("vuelveAEArgentina", 0);
					PlayerPrefs.SetInt ("totemIHabilitado", 1);

					SceneManager.LoadScene ("DescubriendoParque");
				}
					break;
				}
			case "EscTotemI":
				{
					    
						contextoDesafio.SetActive(true);
				        avatar.SetActive (true);
				        
						volver.SetActive (true);
						PlayerPrefs.SetString ("UsoPistaI", "0");
				        PlayerPrefs.SetString ("UsoPista", "0");
						PlayerPrefs.SetString("Desafio", "1");
				        player.position = new Vector3 (134f, 102.94f, 249f);
						player.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
				        player.transform.Rotate (Vector3.up * 180);
				       
				       


					break;
				}
			case "EscTotemII":
				{
						contextoDesafio.SetActive (true);
				        avatar.SetActive (true);
						
						volver.SetActive (true);
						PlayerPrefs.SetString ("UsoPistaII", "0");
				        PlayerPrefs.SetString ("UsoPista", "0");
						PlayerPrefs.SetString ("Desafio", "2");
						player.position = new Vector3 (134f, 102.94f, 249f);
						player.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
						player.transform.Rotate (Vector3.up * 180);
					break;
				}
			case "EscTotemIII":
				{
				    contextoDesafio.SetActive (true);
				    avatar.SetActive (true);
					
					volver.SetActive (true);
				    PlayerPrefs.SetString ("UsoPistaIII", "0");
				    PlayerPrefs.SetString("Desafio", "3");
					player.position = new Vector3 (134f, 102.94f, 249f);
					player.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
					player.transform.Rotate (Vector3.up * 180);	
					break;
				}
			case "Inicio":
				{
					
				if (salio == 0) {//Potal cataratas
					SceneManager.LoadScene ("Inicio");
				}
					break;
				}
			case "VolverAEArgentina":
				{
				if (salio == 0) {	
					//Potal cataratas
					PlayerPrefs.SetInt ("vuelveAEArgentina", 1);
					PlayerPrefs.SetString ("Desafio", "EArgentina");
					SceneManager.LoadScene ("EArgentinaII");
				}
					break;
				}
			default:
				// You can use the default case.
				break;
			}

		//}

	}


	void OnBarProgressChange(float value){
		print ("Bar progress is:" + value);
	}


	void OnBarProgressDone(){
		print ("Radial progress is done!");
	}

	
}
