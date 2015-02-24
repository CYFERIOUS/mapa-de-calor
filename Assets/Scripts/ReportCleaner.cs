using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReportCleaner : MonoBehaviour {
	public InputField Direction;
	public InputField Date;
	public InputField TimeInput;
	public InputField Crime;
	public InputField Description;

	public void ReportInputClean(){
		Direction.text = "";
		Date.text = "";
		TimeInput.text="";
		Crime.text = "";
		Description.text = "";
	}
}
