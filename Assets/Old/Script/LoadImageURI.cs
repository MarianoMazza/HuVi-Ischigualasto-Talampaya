using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadImageURI : LoadVideoManager {
	//private string urlimage = "http://people.videolan.org/~jb/Builds/360/360_videos/Mountain_360.jpg";
    public RawImage imagen;
    private WWW www;
    public Image barraImagenLoading;
    public Text porcentajeImagenLoading;

	// Use this for initialization
	IEnumerator Start () {
		www = new WWW("http://people.videolan.org/~jb/Builds/360/360_videos/Mountain_360.jpg"); ///*url + image*/
        yield return www;
        imagen.texture =www.texture;
		//StartCoroutine(delayImage(2f));	
	}
	
	// Update is called once per frame
	/*void Update () {
        barraImagenLoading.fillAmount = www.progress;
        porcentajeImagenLoading.text = www.progress.ToString("00%");
        Debug.Log(www.progress);





    }*/
		
	IEnumerator delayImage(float time)
	{    yield return new WaitForSeconds(time);
		switch (PlayerPrefs.GetString ("Desafio"))
		{
		case "1":
			{
				SceneManager.LoadScene ("EscTotemI");
				break;
			}
		case "2":
			{
				SceneManager.LoadScene ("EscTotemII");
				break;
			}
		case "3":
			{
				SceneManager.LoadScene ("EscTotemIII");
				break;
			}
		case "EArgentina":
			{
				SceneManager.LoadScene ("EArgentina");
				break;
			}
		default:
			// You can use the default case.
			break;
		}

	
	}
    
}
