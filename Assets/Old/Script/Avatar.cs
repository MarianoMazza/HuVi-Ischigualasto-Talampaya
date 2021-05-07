using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour {

	private GameObject avatar;


	public GameObject getAvatar(){
		return avatar;
	}

	public void setAvatar(GameObject avatar){
		this.avatar = avatar;
	}

}
