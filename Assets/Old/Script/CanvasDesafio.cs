using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class CanvasDesafio : MonoBehaviour {
	
	public Canvas dialogo;
	// Use this for initialization
	void Start () {
		dialogo.enabled = true;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void goMision(){
		dialogo.enabled = false;
	}
}
