using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogWelcome : MonoBehaviour {
	public GameObject o1;
	public  GameObject o2;
	public GameObject b1;
	public  GameObject b2;
	public Canvas avatarSelectedForGame;
	//public GameObject superficie;


	/******
	 * ****menu de confirmacion
	 * ************************/
	public GameObject menuConfirmacionOnline;
	public GameObject menuConfirmacionOffline;
	public GameObject cerrar;

	/********
	 * *****pantalla Inicial
	 * ************************/
	public GameObject image;
	public GameObject playButton;


	// Use this for initialization
	void Start () {
		
        if (PlayerPrefs.GetString ("Desafio") == "Inicio"){
			PlayerPrefs.SetString ("Desafio", "");
			StartCoroutine (delay (0f, "active"));
		}else{
			Debug.LogError ("El valor de desafio es:" + PlayerPrefs.GetString ("Desafio"));
			o1.SetActive (false);
			o2.SetActive (false);
			avatarSelectedForGame.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void play(){
		StartCoroutine (delay (2f, "active"));
	}

	public void modoJuego(){
		StartCoroutine (delay (2f, "volverModoJuego"));
	}
	public void online(){
		string filePath = Application.persistentDataPath + "/menuOnline_ofline.txt";
		string[] registros = new string[1024];
		registros [0] = "Trabajando_online";
		File.WriteAllLines(filePath,registros);
		Debug.LogError (filePath);
		StartCoroutine (delay (2f, "online"));
	}
	public void offline(){
		string filePath = Application.persistentDataPath + "/menuOnline_ofline.txt";
		string[] registros = new string[1024];
		registros [0] = "Trabajando_offline";
		File.WriteAllLines(filePath,registros);
		Debug.LogError (filePath);
		StartCoroutine (delay (2f, "offline"));

	}

	//StartCoroutine (delay (2f, "idem"));


	IEnumerator delay(float time, string accion)
	{


		yield return new WaitForSeconds(time);

		switch (accion)
		{
		case "play":
			{
				b1.SetActive (true);
				b2.SetActive (true);
				image.SetActive (false);
				playButton.SetActive (false);	
				break;
			}
		case "online":
			{
				this.disableOptionMod ();
				PlayerPrefs.SetString ("wifi", "1");
				this.activarMenuConfirmacionOnline ();	
				break;
			}
		case "offline":
				{
					this.disableOptionMod ();
					PlayerPrefs.SetString ("wifi", "-1");
					this.activarMenuConfirmacionOffline ();
					break;
				}
		case "activeGame":
			{

				PlayerPrefs.SetString ("Desafio", "Inicio");
				SceneManager.LoadScene ("VideoAyuda");
				break;

			}
		case "active":
			{
				//Seteamos modo offline por defecto

				PlayerPrefs.SetString ("wifi", "-1");
				this.disableOptionMod ();
				menuConfirmacionOnline.SetActive(false);
				menuConfirmacionOffline.SetActive(false);
				cerrar.SetActive(false);
				o1.SetActive (true);
				o2.SetActive (true);
				//superficie.SetActive (true);
				avatarSelectedForGame.enabled = true;
				break;
			}
		case "volverModoJuego":
			{
				PlayerPrefs.SetString ("Desafio", "");
				menuConfirmacionOnline.SetActive(false);
				menuConfirmacionOffline.SetActive(false);
				cerrar.SetActive(false);
				b1.SetActive (true);
				b2.SetActive (true);
				image.SetActive (false);
				playButton.SetActive (false);

				o1.SetActive (false);
				o2.SetActive (false);
				avatarSelectedForGame.enabled = false;

				break;
			}
			default:
				// You can use the default case.
				break;
			}
	
	}  

	private void disableOptionMod(){
		b1.SetActive (false);
		b2.SetActive (false);
		image.SetActive (false);
		playButton.SetActive (false);
	}

	public void enabledOptionMod(){
		StartCoroutine (delay (2f, "volverModoJuego"));


	}


	public void activateGame(){
		StartCoroutine (delay (2f, "activeGame"));


	}

	private void activarMenuConfirmacionOnline(){
		menuConfirmacionOnline.SetActive(true);
		cerrar.SetActive(true);
		
	}
	private void activarMenuConfirmacionOffline(){
		menuConfirmacionOffline.SetActive (true);
		cerrar.SetActive (true);

	}



}
