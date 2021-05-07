using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//http://people.videolan.org/~jb/Builds/360/360_videos/eagle.mp4
//"http://people.videolan.org/~jb/Builds/360/360_videos/Mountain_360.jpg"
public class LoadVideoManager : GetAndSetServer {
	protected int salio = 0;
	public static string image;


	// Use this for initialization
	void Start () {
		
	}

	private void loadVideoObjet(){
		
		salio = 0;
		StartCoroutine(delay(2f, "loadVideoAndActionObject", null));
	}

	public void loadVideo(){
		if (PlayerPrefs.GetString ("wifi") == "1") {
			this.loadVideoAndAction (urlVideo);
		} 

		if (PlayerPrefs.GetString("wifi") == "-1") {
			this.loadVideoObjet ();
		}



	}
	private void loadVideoAndAction(string v){
		salio = 0;
		StartCoroutine(delay(2f, "loadVideoAndAction", v));
	}
	// Update is called once per frame
	public void loadVideo360 (string v) {
		salio = 0;
		StartCoroutine(delay(2f, "loadVideo360", v));

	}

	public void loadVideo (string v) {
		salio = 0;
		StartCoroutine(delay(2f, "loadVideo", v));

	}

	public void loadImage (string i) {
		salio = 0;
		StartCoroutine(delay(2f, "loadImage", i));

	}

	public void exitVideo(string escena){
		salio = 0;
		//SceneManager.LoadScene ("VideoBoard", LoadSceneMode.Single);
		//StartCoroutine(delay(2f, "exitVideo", null));
		SceneManager.LoadScene(escena);
	}

	public void exitImagen(){
		salio = 0;
		//SceneManager.LoadScene ("VideoBoard", LoadSceneMode.Single);
		//StartCoroutine(delay(2f, "exitVideo", null));
		if (PlayerPrefs.GetInt ("Desafio") == 1) {
			SceneManager.LoadScene ("EscTotemI");
		}
		if (PlayerPrefs.GetInt ("Desafio") == 2) {
				SceneManager.LoadScene ("EscTotemII");
		} 
		if (PlayerPrefs.GetInt ("Desafio") == 3) {
					SceneManager.LoadScene ("EscTotemIII");
		}

	}

	public void outOption(){
		salio = 1;
	}

	// Manejo de los video e imagenes con carga asincronica, para mejorar un toque la performance.
	IEnumerator delay(float time, string accion, string r)
	{
		print(Time.time);
		yield return new WaitForSeconds(time);
		if (salio == 0) {
			switch (accion)
			{
			case "loadVideo360":
				{
					video = r;
					SceneManager.LoadScene("Video360App");
					break;
				}
			case "loadVideo":
				{
					video = r;
					SceneManager.LoadScene("Video");
					break;
				}
			case "loadVideoAndAction":
				{
					video = r;
					PlayerPrefs.SetString ("Desafio","EArgentina");
					PlayerPrefs.SetInt ("Action",1);
					PlayerPrefs.SetInt ("vuelveAEArgentina",1);
					SceneManager.LoadScene("Video");
					break;
				}
			case "loadVideoAndActionObject":
				{
					video = r;
					PlayerPrefs.SetString ("Desafio","EArgentina");
					PlayerPrefs.SetInt ("Action",1);
					PlayerPrefs.SetInt ("vuelveAEArgentina",1);
					SceneManager.LoadScene("VideoPlay");

					break;
				}
			case "loadImage":
				{
					image = r;
					SceneManager.LoadSceneAsync("cargaImagen");
					break;
				}
			default:
				// You can use the default case.
				break;
			}

		}


	}


}
