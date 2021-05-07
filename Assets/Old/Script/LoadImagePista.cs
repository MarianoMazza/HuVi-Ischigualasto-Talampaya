using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadImagePista : MonoBehaviour {

	public Texture imagen1;
	public Texture imagen2;
	public Texture imagen3;

	// Use this for initialization
	void Start () {

		Debug.LogError (PlayerPrefs.GetString ("Desafio"));

		//Fetch the Renderer from the GameObject



		switch (PlayerPrefs.GetString ("Desafio"))
		{
		case "1":
			{

				//Set the Texture you assign in the Inspector as the main texture (Or Albedo)
				transform.GetComponent<RawImage>().texture =imagen1;


				break;
			}
		case "2":
			{
				transform.GetComponent<RawImage>().texture =imagen2;
				break;
			}
		case "3":
			{
				transform.GetComponent<RawImage>().texture =imagen3;
				break;
			}
		default:
			// You can use the default case.
			break;
		}	
	}
}
