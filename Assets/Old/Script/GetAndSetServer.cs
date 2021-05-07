using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetAndSetServer : MonoBehaviour {
	public InputField urlServer;
	public string urlVideo;
	public static string video;
	public Text ftext;
	public static string url;
	public void start(){

	}

	public void setInput(){
		
		if (urlServer.text == "") {
			url = urlServer.text;
			urlServer.image.color = Color.red;

		} else {	
			url = urlServer.text;
			urlServer.image.color = Color.green;
		}

	}

	/*public void OnGUI(){
		TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);

	}*/

}
