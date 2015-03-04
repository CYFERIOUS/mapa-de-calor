using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ReportSender: MonoBehaviour {

	public InputField ubicationField;
	public InputField commentsField;
	public Button submitButton;

	public 

	void Start(){
		submitButton.onClick.AddListener (delegate {
			HandleSubmitClicked();
		});
	}

	private void HandleSubmitClicked ()
	{
		FormData formdata = CreateFormData ();
		ReportSaver saver = new ReportSaver();
		saver.SetStorage (new PlayerPrefStorage());
		saver.Save (formdata);

	}

	private FormData CreateFormData ()
	{
		 FormData data = new FormData ();
		data.annotation = GetAnnotation ();
		data.comments = commentsField.text;

		return data;
	}

	private Vector2 GetAnnotation ()
	{
		string ubicationText = ubicationField.text;
		string[] coordinates = ubicationText.Split (new string[1]{" , "}, StringSplitOptions.None);
		return new Vector2 (float.Parse(coordinates[0]), float.Parse(coordinates[1]));
	}

	public  DateTime ConvertFromUnixTimestamp(double timestamp)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return origin.AddSeconds(timestamp);
	}
	
	public static double ConvertToUnixTimestamp(DateTime date)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		TimeSpan diff = date.ToUniversalTime() - origin;
		Debug.Log (Math.Floor(diff.TotalSeconds));
		return Math.Floor(diff.TotalSeconds);
	}


}
