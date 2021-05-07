using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadPista : MonoBehaviour {
	public GameObject pista1;
	public GameObject pista2;
	public GameObject pista3;
	AudioSource audioData;
	// Use this for initialization
	public void activePista () {
		PlayerPrefs.SetString ("UsoPista", "1");
		switch (PlayerPrefs.GetString ("Desafio"))
		{
		case "1":
			{

				pista1.SetActive (true);
				audioData = GetComponent<AudioSource> ();
				audioData.Play ();
				PlayerPrefs.SetString ("UsoPistaI", "1");
				break;
			}
		case "2":
			{
				pista2.SetActive (true);
				audioData = GetComponent<AudioSource> ();
				audioData.Play ();
				PlayerPrefs.SetString ("UsoPistaII", "2");
				break;
			}
		case "3":
			{
				pista3.SetActive (true);
				audioData = GetComponent<AudioSource> ();
				audioData.Play ();
				break;
			}
		default:
			// You can use the default case.
			break;
		}	
	}
	// Update is called once per frame
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		

	}





		
	}

