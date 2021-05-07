using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelDialogReturn : MonoBehaviour {
	public GameObject menuConfirmacion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void cancel(){
		StartCoroutine (delay (2f));
	}

	public IEnumerator delay(float time)
	{

		yield return new WaitForSeconds (time);
		menuConfirmacion.SetActive (false);
	}
}
