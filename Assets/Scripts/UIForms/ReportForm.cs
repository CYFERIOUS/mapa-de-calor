using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReportForm : MonoBehaviour {
	public InputField DayInput;
	private ReportFormValidator validator;

	public void Start()
	{
		validator = new ReportFormValidator ();
	}

	public void Update() {

		validator.Day = DayInput.text;
		if (validator.IsValid)
			DayInput.image.color = Color.white;
		else
			DayInput.image.color = Color.red;
	}
}