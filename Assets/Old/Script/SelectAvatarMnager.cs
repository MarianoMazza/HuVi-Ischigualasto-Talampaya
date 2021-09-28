using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[RequireComponent (typeof(AudioSource))]
public class SelectAvatarMnager : MenuManager {
	public Canvas  canvas;
	protected Avatar avatarSelection;
	public GameObject efectos1;
	public GameObject efectos2;
	public GameObject efectos3;
	public GameObject baseAvatar;

	AudioSource audioData;
	void Start () {
		filePath = Application.persistentDataPath + "/INICIAL_menuJuego.txt";
		salio = 0;
		//canvas.enabled = false;
	}
		
	// Update is called once per frame
	void Update () {
		
	}
	public void Avatar(){
		salio = 0;
		subtittles.SetActive (true);
		audioData = subtittles.transform.GetComponent<AudioSource> ();
		audioData.Play ();
		StartCoroutine(delaySubtittle(2f));
		StartCoroutine(delay(2f,"habilitarDeshabilitarCanvas"));


	}




IEnumerator delaySubtittle(float time)
{
	print (Time.time);
	yield return new WaitForSeconds (time);
		subtittles.SetActive (false);
}


	public void QuitOpAvatar(){
		salio = 0;
		StartCoroutine(delay(2f,"DeshabilitarCanvas"));
	}

	IEnumerator delay(float time, string accion)
	{
		print(Time.time);
		yield return new WaitForSeconds(time);
		if (salio == 0) {

			switch (accion)
			{
			case "habilitarDeshabilitarCanvas":
				{
					//CONTROL INTERACCION

					if (!File.Exists (Application.persistentDataPath + "/INICIAL_menuJuego.txt")) {
						registros [1] = "-AvatarSelect";
						File.WriteAllLines (filePath, registros);
					} else {
						string[] menuInfo = File.ReadAllLines (filePath);
						menuInfo [1] = menuInfo[1] + "-AvatarSelect";
						File.WriteAllLines (filePath, menuInfo);
					}
					Debug.LogError (filePath);
					/////
					canvas.enabled =true;
					baseAvatar.SetActive(true);
					break;
				}
			default:
				// You can use the default case.
				break;
			}
		
	    }

	}
}





