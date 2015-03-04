using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ReportCleaner : MonoBehaviour {
	public InputField Direction;
	public InputField Date;
	public InputField TimeInput;
	public InputField Crime;
	public InputField Description;
	public FormData reporter;
	public DateTime time;

	void start() {
	}

	public void ReportInputClean(){
		Direction.text = "";
		Date.text = "";
		TimeInput.text="";
		Crime.text = "";
		Description.text = "";
	}

}
