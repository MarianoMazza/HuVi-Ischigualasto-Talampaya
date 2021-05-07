using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour {
	public Texture2D textureMira;
	Rect position;
	// Use this for initialization
	void Start () {
		position = new Rect((Screen.width-textureMira.width)/2, (Screen.height-textureMira.height)/2,textureMira.width, textureMira.height);

		
	}
	
	public void onGUI(){
		GUI.DrawTexture (position, textureMira);
	}



}
