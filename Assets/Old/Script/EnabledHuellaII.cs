using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledHuellaII : MonoBehaviour {
	public GameObject huellaVerde;
	public GameObject huellaDorada;
	public GameObject huellaGris;
	// Use this for initialization
	void Start () {
		huellaGris.SetActive (false);
			//if (PlayerPrefs.GetString ("UsoPistaII") == "0") {
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
