using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledHuellaIII : MonoBehaviour {
	public GameObject huellaVerde;
	public GameObject huellaDorada;
	public GameObject huellaGris;
	// Use this for initialization
	void Start () {
		Debug.LogError ("TOTEM1"+PlayerPrefs.GetInt ("avanzoTotemI"));
		Debug.LogError ("USO_PISTA1"+PlayerPrefs.GetString ("UsoPistaI"));

		Debug.LogError ("TOTEM2"+PlayerPrefs.GetInt ("avanzoTotemII"));
		Debug.LogError ("USO_PISTA2"+PlayerPrefs.GetString ("UsoPistaII"));

		Debug.LogError ("TOTEM3"+PlayerPrefs.GetInt ("avanzoTotemIII"));
		Debug.LogError ("USO_PISTA3"+PlayerPrefs.GetString ("UsoPistaIII"));
		huellaGris.SetActive (false);
		//if (PlayerPrefs.GetString ("UsoPistaIII") =="0") {
				huellaDorada.SetActive (true);
				huellaVerde.SetActive (false);
		/*	} else {
				huellaVerde.SetActive (true);
				huellaDorada.SetActive (false);
			}*/

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
