using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPremio : MonoBehaviour {
	public GameObject premio;
	// Use this for initialization
	void Start () {
		Debug.LogError ("TOTEM"+PlayerPrefs.GetInt ("avanzoTotemI"));
		Debug.LogError ("USO_PISTA"+PlayerPrefs.GetString ("UsoPistaI"));

		if ( PlayerPrefs.GetInt ("avanzoTotemI")==1) {
			if (PlayerPrefs.GetString ("UsoPistaI") != "1") {
				premio.SetActive (true);
			} else {
				premio.SetActive (false);
			}
		} else {
			if (PlayerPrefs.GetInt ("avanzoTotemII") == 1) {
				if (PlayerPrefs.GetString ("UsoPistaII") != "1") {
					premio.SetActive (true);
				} else {
					premio.SetActive (false);
				}
			} else {
				premio.SetActive (false);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
