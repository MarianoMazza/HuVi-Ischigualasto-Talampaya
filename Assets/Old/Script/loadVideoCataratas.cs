using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class loadVideoCataratas : GetAndSetServer {
	
	protected int salio = 0;



	/************************************************
	 *  VIDEOS CORRESONDIENTES A LOS PREMIOS
	 * **********************************************/

	public void loadPremioAlDesafioI(){

		salio = 0;
		PlayerPrefs.SetInt ("VideoPremioI", 1);
		if (PlayerPrefs.GetString ("wifi") == "1") {
			StartCoroutine(delay(2f, "loadVideo", urlVideo));
		} 

		if (PlayerPrefs.GetString("wifi") == "-1") {
			StartCoroutine(delay(2f, "loadPremioI",null));	
		}

	}

	public void loadPremioAlDesafioII(){

		salio = 0;
		PlayerPrefs.SetInt ("VideoPremioII", 1);
		if (PlayerPrefs.GetString ("wifi") == "1") {
			StartCoroutine(delay(2f, "loadVideo", urlVideo));
		} 

		if (PlayerPrefs.GetString("wifi") == "-1") {
			StartCoroutine(delay(2f, "loadPremioII",null));	
		}

	}


	/******************************************************
	 * ****************************************************/



	/************************************************
	 *   VIDEOS CORRESONDIENTES A LA PASARELA III HACIA
	 * LA GARGANTA DEL DIABLO
	 * **********************************************/
	public void loadLlegadaCataratas(){

		salio = 0;
		PlayerPrefs.SetInt ("EntradaCataratas", 2);
		if (PlayerPrefs.GetString ("wifi") == "1") {
			StartCoroutine(delay(2f, "loadVideo", urlVideo));
			} 

		if (PlayerPrefs.GetString("wifi") == "-1") {
			StartCoroutine(delay(2f, "loadLlegadaCataratas",null));	
		}

	}

	public void loadEntradaGarganta(){

		salio = 0;
		PlayerPrefs.SetInt ("EntradaCataratas",3);
		if (PlayerPrefs.GetString ("wifi") == "1") {
			StartCoroutine(delay(2f, "loadVideo",urlVideo));
		} 

		if (PlayerPrefs.GetString("wifi") == "-1") {
			StartCoroutine(delay(2f, "loadEntradaGarganta",null));
		}


	}

	public void loadGarganta360(){
		
		salio = 0;
		if (PlayerPrefs.GetString ("wifi") == "1") {
			StartCoroutine(delay(2f, "loadVideo360",urlVideo));
		} 

		if (PlayerPrefs.GetString("wifi") == "-1") {
			StartCoroutine(delay(2f, "loadGarganta360",null));	
		}

	
	}

	/***********************************************************
	 * *********************************************************/

	public void outOption(){
		salio = 1;
	}


	IEnumerator delay(float time, string accion, string r)
	{
		Debug.Log (r);
		print (Time.time);
			yield return new WaitForSeconds (time);
	
		if (salio == 0) {
			switch (accion) {
			case "loadLlegadaCataratas":
				{
					
					SceneManager.LoadSceneAsync ("VideoPlayEntradaCat");

				}
				break;
			case "loadEntradaGarganta":
				{
					
					SceneManager.LoadSceneAsync ("VideoPlayEntradaGar");
				}
				break;
			case "loadGarganta360":
				{
					
					SceneManager.LoadSceneAsync ("VideoGarganta360");
				}
				break;

			case "loadVideo":
				{
					video = r;
					SceneManager.LoadSceneAsync("Video");
				}
				break;
			case "loadVideo360":
				{
					video = r;
					SceneManager.LoadSceneAsync("Video360App");
				}
				break;
			case "loadPremioI":
				{
					video = r;
					PlayerPrefs.SetString ("UsoPistaI", "1");
					SceneManager.LoadSceneAsync("VideoPlayPremioI");
				}
				break;
			case "loadPremioII":
				{
					video = r;
					PlayerPrefs.SetString ("UsoPistaII", "1");
					SceneManager.LoadSceneAsync("VideoPremioII360");
				}
				break;
			default:
			// You can use the default case.
				break;
			}
		}
	}


}
