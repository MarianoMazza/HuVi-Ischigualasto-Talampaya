using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class LoadVideoObject : MonoBehaviour {
	VideoPlayer video;
	public float time;
	void Start ()
	{
		video = GetComponent<VideoPlayer> ();
		video.Prepare ();
		video.Play ();
		//Debug.Log (PlayerPrefs.GetString ("Desafio"));

		//StartCoroutine(delayVideo (time));

	}

	IEnumerator delayVideo(float time)
	{   
		yield return new WaitForSeconds(time);
		// Activa una colección para liberar memoria.
		GC.Collect ();

		switch (PlayerPrefs.GetString ("Desafio"))
		{
		case "1":
			{
				
				SceneManager.LoadScene ("DescubriendoParque");

				break;
			}
		case "2":
			{
				
				SceneManager.LoadScene ("DescubriendoParque");
				break;
			}
		case "3":
			{
				PlayerPrefs.SetInt ("vuelveAEArgentina", 1);
				PlayerPrefs.SetString ("Desafio", "EArgentina");
				//Para q el portal me aparezca abierto (script q maneja el movieminto del portal: GameObjectManager)
				PlayerPrefs.SetInt ("Action", 1);
				//Indicamos que avanzamos al eje1
				PlayerPrefs.SetInt ("avanzo_eje",1);
				SceneManager.LoadScene ("EArgentinaII");


				//----------
				//ACA TENDRIAMOS Q Cambiar le color de la esfera
				Debug.Log (PlayerPrefs.GetString ("VUELVE DEL VIDEO 360"));
				/*SceneManager.LoadScene ("EscTotemIII");
				vp.Stop ();*/
				break;
			}
		case "EArgentina":
			{
				PlayerPrefs.SetInt ("Action",1);
				PlayerPrefs.SetInt ("vuelveAEArgentina",1);
				SceneManager.LoadScene ("EArgentinaII");
				//vp.Stop ();
				break;
			}
		case "Inicio":
			{
				SceneManager.LoadScene ("Inicio");
				//vp.Stop ();
				break;
			}
		default:
			// You can use the default case.
			break;
		}


	}


}
