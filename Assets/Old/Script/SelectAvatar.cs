using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class SelectAvatar : MenuManager {
	 string filePathAvatar = "";
	 string[] registrosAvatar= new string[1024];
	// Use this for initialization

		

	private GameObject[] avatarList;
	private int sizeAvatar;
	public Transform transLis;
	public Canvas canvas;
	public GameObject fondoAvatarSeleccionado;
	private int index;
	public GameObject efectos1;
	public GameObject efectos2;
	public GameObject efectos3;
	public GameObject baseAvatar;
	//Inicializamos el juego por ahora aca;
	//private Game game;
	void Start () {
		filePathAvatar = Application.persistentDataPath + "/INICIAL_menuAvatar.txt";
		//Inicializamos la lista de Avatares
		//game = new Game();
		sizeAvatar = transLis.childCount;

		index = PlayerPrefs.GetInt("avatarSelected");

		Debug.Log ("Avatar activo" + index);
		fondoAvatarSeleccionado.SetActive (false);
		this.loadListAvatars();

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
	// Update is called once per frame
	void Update () {

	}

	public void left(){
		salio = 0;
		fondoAvatarSeleccionado.SetActive (false);
		StartCoroutine(delay(1f,"left"));

	}

	public void right(){
		salio = 0;
		fondoAvatarSeleccionado.SetActive (false);
		StartCoroutine(delay(1f,"right"));

	}


	//Avatar elegido
	public void selectedAvatar(){
		salio = 0;
		PlayerPrefs.SetInt("avatarSelected", index);
		fondoAvatarSeleccionado.SetActive (true);
		baseAvatar.SetActive (false);
		canvas.enabled = !canvas.enabled;

	}
	//Manejador de Opciones en base a times
	IEnumerator delay(float time, string accion)
	{
		//print(Time.time);
		yield return new WaitForSeconds(time);
		if (salio == 0) {

			switch (accion)
			{
			case "left":
				{

					//CONTROL INTERACCION
					if (!File.Exists (Application.persistentDataPath + "/INICIAL_menuAvatar.txt")) {
						registrosAvatar [0] = "-Left";
						File.WriteAllLines (filePathAvatar, registrosAvatar);
					} else {
						string[] menuInfo = File.ReadAllLines (filePathAvatar);
						menuInfo [0] = menuInfo[0] + "-Left";
						File.WriteAllLines (filePathAvatar, menuInfo);
					}

					Debug.LogError (filePathAvatar);
					/////
					this.disableAvatar(index);
					if (index == 0) {
						index = sizeAvatar - 1;
					} else {
						index = index-1;
					}
					this.activeAvatar (index);
					StartCoroutine(delay (1f, "left"));
					break;
				}
			case "right":
				{
					//CONTROL INTERACCION
					if (!File.Exists (Application.persistentDataPath + "/INICIAL_menuAvatar.txt")) {
						registrosAvatar [1] = "-Right";
						File.WriteAllLines (filePathAvatar, registrosAvatar);
					} else {
						string[] menuInfo = File.ReadAllLines (filePathAvatar);
						menuInfo [1] = menuInfo[1] + "-Right";
						File.WriteAllLines (filePathAvatar, menuInfo);
					}
					//Debug.LogError (filePathAvatar);
					/////
					this.disableAvatar(index);
					avatarList [index].SetActive (false);
					if (index == (sizeAvatar - 1)) {
						index = 0;
					} else {
						index = index+1;
					}
					//Debug.Log (index);
					this.activeAvatar (index);
					StartCoroutine(this.delay (1f, "right"));
					break;
				}
			case "selected":
				{
					//CONTROL INTERACCION
					if (!File.Exists (Application.persistentDataPath + "/INICIAL_menuAvatar.txt")) {
						registros [2] = "-Selected";
						File.WriteAllLines (filePath, registros);
					} else {
						string[] menuInfo = File.ReadAllLines (filePath);
						menuInfo [2] = menuInfo[2] + "-Selected";
						File.WriteAllLines (filePath, menuInfo);
					}
					Debug.LogError (filePath);
					/////
					Debug.Log ("SE Selecciona avatar" + index);
					//this.avatarSelection.setAvatar (avatarList [index]);
					//game.setGamer (avatarSelection);
					//Debug.Log (game.getGamer().getAvatar());
					//Almacenamos el index para pasar el dato entre escenas
					PlayerPrefs.SetInt("avatarSelected", index);
					fondoAvatarSeleccionado.SetActive (true);
					break;
				}
			default:
				// You can use the default case.
				break;
			}

		}

	}

	private void activeAvatar(int index){
		avatarList [index].SetActive (true);
	}

	private void disableAvatar(int index){
		avatarList [index].SetActive (false);
	}

}
