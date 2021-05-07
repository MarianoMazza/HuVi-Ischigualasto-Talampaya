using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEmocion : MonoBehaviour {
	
	protected string filePath = "";
	protected string[] registros= new string[4];
	public GameObject menuEmocion;

	/***elementos q se activaran al caragar la ecena***/
	public GameObject progress;
	public BarProgress barProgress;

	// Use this for initialization
	void Start () {
		filePath = Application.persistentDataPath + "/EMOCION_menuJuego.txt";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void feliz (string nameEscene){
		StartCoroutine(delay(2f, "feliz", nameEscene));
	}

	public void contento (string nameEscene){
		StartCoroutine(delay(2f, "contento", nameEscene));
	}

	public void buenHumor (string nameEscene){
		StartCoroutine(delay(2f, "buenHumor", nameEscene));
	}



	IEnumerator delay(float time, string accion, string nameSecene)
	{
		print(Time.time);
		progress.SetActive (true);
		yield return new WaitForSeconds(time);

			switch (accion)
			{
			case "feliz":
				{

					/************************************
					 * ********CONTROL INTERACCION
					 * *********************************/

					if (!File.Exists (Application.persistentDataPath + "/EMOCION_menuJuego.txt")) {
						registros [0] = "-Feliz";
						File.WriteAllLines (filePath, registros);
					} else {
						string[] menuInfo = File.ReadAllLines (filePath);
						menuInfo [0] = menuInfo[0] + "-Feliz";
						File.WriteAllLines (filePath, menuInfo);
					}
					Debug.LogError (filePath);


					break;
				}
		case "contento":
			{

				/************************************
					 * ********CONTROL INTERACCION
					 * *********************************/

				if (!File.Exists (Application.persistentDataPath + "/Emocion_menuJuego.txt")) {
					registros [1] = "-Contento";
					File.WriteAllLines (filePath, registros);
				} else {
					string[] menuInfo = File.ReadAllLines (filePath);
					menuInfo [1] = menuInfo[1] + "-Contento";
					File.WriteAllLines (filePath, menuInfo);
				}
				Debug.LogError (filePath);


				break;
			}
		case "buenHumor":
			{

				/************************************
					 * ********CONTROL INTERACCION
					 * *********************************/

				if (!File.Exists (Application.persistentDataPath + "/Emocion_menuJuego.txt")) {
					registros [2] = "-BuenHumor";
					File.WriteAllLines (filePath, registros);
				} else {
					string[] menuInfo = File.ReadAllLines (filePath);
					menuInfo [2] = menuInfo[2] + "-BuenHumor";
					File.WriteAllLines (filePath, menuInfo);
				}
				Debug.LogError (filePath);


				break;
			}
			default:
				// You can use the default case.
				break;
			}

		/******************************************
					 * *****************************************/
	
		barProgress.OnChange (this.OnBarProgressChange);
		barProgress.OnDone (this.OnBarProgressDone);
		AsyncOperation operation = SceneManager.LoadSceneAsync (nameSecene);
		//operation.allowSceneActivation = false;

		while (!operation.isDone) {
			barProgress.SetValue (operation.progress);
			yield return null;
		}


	}

	void OnBarProgressChange(float value){
		print ("Bar progress is:" + value);
	}


	void OnBarProgressDone(){
		print ("Radial progress is done!");
	}


}

