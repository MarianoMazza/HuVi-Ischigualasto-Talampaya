using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigerEnter : MonoBehaviour {

	public void enterHuella(){
		Debug.Log ("pasa huella");
		transform.gameObject.SetActive (false);
	}
}
