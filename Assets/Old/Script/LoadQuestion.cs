using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadQuestion : MonoBehaviour {
	public GameObject text1;
	public GameObject  text2;
	public GameObject  text3;
	public GameObject sound1;
	public GameObject  sound2;
	public GameObject  sound3;

	
	// Use this for initialization
	void Start () {


		switch (PlayerPrefs.GetString ("Desafio"))
		{
		case "1":
			{
				text1.SetActive( true);
				sound1.SetActive (true);
				break;
			}
		case "2":
			{
				text2.SetActive (true);
				sound2.SetActive (true);
				break;
			}
		case "3":
			{
				text3.SetActive (true);
				sound3.SetActive (true);

				break;
			}
		default:
			// You can use the default case.
			break;
		}	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
