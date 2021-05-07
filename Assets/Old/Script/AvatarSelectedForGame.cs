using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelectedForGame : MonoBehaviour {
	private GameObject[] avatarList;
	private int sizeAvatar;
	public Transform transLis;
	public Canvas canvas;
	private int index;
	// Use this for initialization
	void Start () {
		//Inicializamos la lista de Avatares
		//game = new Game();
		sizeAvatar = transLis.childCount;

		index = PlayerPrefs.GetInt("avatarSelected");

		Debug.Log ("Avatar activo" + index);

		this.loadListAvatars();
	}
	
	// Update is called once per frame
	void Update () {
		avatarList [index].SetActive (false);
		avatarList [PlayerPrefs.GetInt("avatarSelected")].SetActive (true);
		index = PlayerPrefs.GetInt ("avatarSelected");
	}

	//Carga la lista de Avatares disponibles
	private void loadListAvatars(){

		Debug.Log (sizeAvatar);
		avatarList = new GameObject[sizeAvatar];
		//Cargamos la lista con los avatares
		for (int i=0; i< sizeAvatar; i++){
			avatarList[i] = transform.GetChild (i).gameObject;
		}
		//Desacivmos los avatares
		foreach (GameObject avatar in avatarList) {
			avatar.SetActive (false);
		}
		//Habilitamos el primero de los avatares; (va a ser el asignado por defecto)
		if(avatarList[PlayerPrefs.GetInt("avatarSelected")]){
			avatarList [PlayerPrefs.GetInt("avatarSelected")].SetActive (true);
			/*avatarSelection = new Avatar();
			avatarSelection.setAvatar (avatarList [0]);
			game.setGamer (avatarSelection);
			Debug.Log (game.getGamer());*/
		}

	}
}
