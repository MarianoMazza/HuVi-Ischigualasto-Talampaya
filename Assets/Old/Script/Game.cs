using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	private Avatar gamer;
	public Transform transf;
	public void setGamer(Avatar gamer){
		this.gamer = gamer;
	}

	public Avatar getGamer(){
		return this.gamer;
	}

	void Start () {
		
		Debug.Log (this.getGamer().getAvatar());

	}


}
