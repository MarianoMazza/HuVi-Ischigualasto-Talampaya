using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarProgress : MonoBehaviour {
	public Image fillImage;
	public Text textLabel;
	private float value = 0f;
	private bool isDone = false;

/*void Awake(){
		this.fillImage = this.transform.Find ("Fill").transform.GetComponent<Image>();
		this.textLabel = this.transform.Find ("TextLabel").transform.GetComponent<Text>();
	}

*/
	void Start () {
		this.fillImage.fillAmount = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isDone) {
			if (this.OnDoneEvent != null) {
				this.OnDoneEvent ();

			}
			this.OnDoneEvent = null;
			this.OnChangeEvent = null;
			return;
		}
		if (this.OnChangeEvent != null) {
			this.OnChangeEvent ((int)(this.value * 100));
		}
		this.fillImage.fillAmount = this.value;
		this.textLabel.text = (this.value>=1 )? "Done!" : (this.value*100)+"%";
		this.isDone = (this.value >= 1) ? true : false;
	}


	#region Events
	public void OnChange(ValueChange method){
		this.OnChangeEvent += method;
	}
	public void OnDone(ProgressDone method){
		this.OnDoneEvent += method;
	}
	public delegate void ValueChange(float value);
	private event ValueChange OnChangeEvent;
	public delegate void ProgressDone ();
	private event ProgressDone OnDoneEvent;

	#endregion

	public void SetValue(float value){
		this.value = value;
	}

	public float GetValue(){
		return this.value;
	}


}
