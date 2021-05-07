using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif

[RequireComponent (typeof(AudioSource))]
public class MenuManager : MonoBehaviour {
    string url = "https://yt3.ggpht.com/-6k_c7iwccMs/AAAAAAAAAAI/AAAAAAAAAAA/ayDihdE710o/s88-c-k-no-mo-rj-c0xffffff/photo.jpg";
    Texture2D textura;
	protected int salio = 0;
	protected string filePath = "";
	protected string[] registros= new string[1024];
	//El menu emocion queda sin uso
	public GameObject menuEmocion;

	public GameObject progress;
	public BarProgress barProgress;


	public GameObject subtittles;
	AudioSource audioData;



    // Use this for initialization
    void Start () {
		 filePath = Application.persistentDataPath + "/INICIAL_menuJuego.txt";

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadEscene(string nameEscene){
		salio = 0;
		Debug.Log("entro");
		subtittles.SetActive (true);
		audioData = subtittles.transform.GetComponent<AudioSource> ();
		audioData.Play ();
		StartCoroutine(delaySubtittle(2f));
		StartCoroutine(delay(2f, "cargarEscena", nameEscene));

	}



	IEnumerator delaySubtittle(float time)
	{
		print (Time.time);
		yield return new WaitForSeconds (time);
			subtittles.SetActive (false);
	}


	public void outOption(){
		salio = 1;
	}

	public void Exit(){
		salio = 0;
		subtittles.SetActive (true);
		audioData = subtittles.transform.GetComponent<AudioSource> ();
		audioData.Play ();
		StartCoroutine(delaySubtittle(2f));
		PlayerPrefs.DeleteAll ();
		Debug.Log("entro");
		StartCoroutine(delay(2f, "exitGame", null));
	}
    public void loadImage() {
        
        WWW imgLink = new WWW(url);
        StartCoroutine(imgLink);
        textura = imgLink.texture;
       
    }



	IEnumerator delay(float time, string accion, string nameSecene)
	{
		print(Time.time);
		yield return new WaitForSeconds(time);
		if (salio == 0) {
			switch (accion)
			{
			case "cargarEscena":
				{
					progress.SetActive (true);
					/************************************
					 * ********CONTROL INTERACCION
					 * *********************************/

					if (!File.Exists (Application.persistentDataPath + "/INICIAL_menuJuego.txt")) {
						registros [0] = "-Play";
						File.WriteAllLines (filePath, registros);
					} else {
						string[] menuInfo = File.ReadAllLines (filePath);
						menuInfo [0] = menuInfo[0] + "-Play";
						File.WriteAllLines (filePath, menuInfo);
					}
					Debug.LogError (filePath);

					/******************************************
					 * *****************************************/
					//menuEmocion.SetActive (true);

					PlayerPrefs.DeleteKey("Desafio");
					PlayerPrefs.DeleteKey("Action");
					PlayerPrefs.DeleteKey ("vuelveAEArgentina");
					PlayerPrefs.SetInt ("avanzo_eje",0);


					barProgress.OnChange (this.OnBarProgressChange);
					barProgress.OnDone (this.OnBarProgressDone);
					AsyncOperation operation = SceneManager.LoadSceneAsync (nameSecene);
					//operation.allowSceneActivation = false;

					while (!operation.isDone) {
						barProgress.SetValue (operation.progress);
						yield return null;
					}


				
					break;
				}
			case "exitGame": {
					/************************************
					 * ********CONTROL INTERACCION
					 * *********************************/
					if (!File.Exists (Application.persistentDataPath + "/INICIAL_menuJuego.txt")) {
						registros [3] = "-Closed";
						File.WriteAllLines (filePath, registros);
					} else {
						string[] menuInfo = File.ReadAllLines (filePath);
						menuInfo [3] = menuInfo[3] + "-Closed";
						File.WriteAllLines (filePath, menuInfo);
					}
					Debug.LogError (filePath);
					//////
					Application.Quit();
					break;
				}
			default:
				// You can use the default case.
				break;
			}

		}


	}


	void OnBarProgressChange(float value){
		print ("Bar progress is:" + value);
	}


	void OnBarProgressDone(){
		print ("Radial progress is done!");
	}


}

