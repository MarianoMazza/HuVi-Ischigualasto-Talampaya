using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadVideo : GetAndSetServer {



	string readTextFile()
	{
		
		StreamReader inp_stm = new StreamReader(Application.dataPath+"/"+"video.txt");

		while(!inp_stm.EndOfStream)
		{
			string inp_ln = inp_stm.ReadLine( );
			return inp_ln;
		}

		inp_stm.Close( );  
		return null;
	}

	void Start ()
	{
		var vp = gameObject.AddComponent <VideoPlayer> ();

			//Acceso hardcode url
			//GetAndSetServer server =  GetComponent<GetAndSetServer>();
			Debug.Log (url + video);
			//Text url = server.ftext;
			//http://people.videolan.org/~jb/Builds/360/360_videos/
			//Debug.Log(url.text + "LOG");
			//vp.url = url +"Ruinas360_3.mp4"; 
		    vp.url = video; 
			//Acceso file txt
			//vp.url=readTextFile();
			vp.isLooping =true;
			vp.renderMode = VideoRenderMode.MaterialOverride;
			vp.targetMaterialRenderer = GetComponent < Renderer > ();
			vp.targetMaterialProperty = "_MainTex"; 

			vp.Play ();

		StartCoroutine(delayVideo (10f, vp));

	}

	IEnumerator delayVideo(float time, VideoPlayer  vp)
	{   
		yield return new WaitForSeconds(time);

		switch (PlayerPrefs.GetString ("Desafio"))
		{
		case "1":
			{
				SceneManager.LoadScene ("EscTotemI");
				vp.Stop ();
				break;
			}
		case "2":
			{
				SceneManager.LoadScene ("EscTotemII");
				vp.Stop ();
				break;
			}
		case "3":
			{
				//SceneManager.LoadScene ("EscTotemIII");
				SceneManager.LoadSceneAsync ("DescubriendoParque");
				vp.Stop ();
				break;
			}
		case "EArgentina":
			{
				PlayerPrefs.SetInt ("Action",1);
				PlayerPrefs.SetInt ("vuelveAEArgentina",1);
				SceneManager.LoadScene ("EArgentinaII");
				vp.Stop ();
				break;
			}
		default:
			// You can use the default case.
			break;
		}


	}


}
