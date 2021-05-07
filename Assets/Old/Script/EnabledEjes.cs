using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnabledEjes : MonoBehaviour
{   public GameObject noPasoElDesafio;
	public GameObject pasoDesafio;
    // Start is called before the first frame update
    void Start()
	{   //AVANZO_EJE = 1 (EJE 1)
		//AVANZO_EJE = 2 (EJE 1)
		if (PlayerPrefs.GetInt ("avanzo_eje") != 0){
		if (PlayerPrefs.GetInt ("avanzo_eje") == 1){

			noPasoElDesafio.SetActive(false);
			pasoDesafio.SetActive(true);
			Debug.Log (PlayerPrefs.GetInt ("avanzo_eje"));
		}else{
			noPasoElDesafio.SetActive(true);
			pasoDesafio.SetActive(false);
		}}else{
			noPasoElDesafio.SetActive(true);
		}
			
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
