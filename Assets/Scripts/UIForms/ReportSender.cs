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
	public InputField dateField;
	public InputField hourField;
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
		data.timestamp = GetTimeStamp ();
		return data;
	}

	int GetTimeStamp ()
	{
		String[] date = dateField.text.Split(new String[1]{"-"},StringSplitOptions.None);
		String[] hour = hourField.text.Split(new String[1]{":"},StringSplitOptions.None);
		Debug.Log (date.Length);
		return ConvertToUnixTimestamp(ConvertToDateTime(date, hour));
	}

	DateTime ConvertToDateTime (string[] date, string[] hour)
	{
		int year = int.Parse(date [2]);
		int month = int.Parse(date [1]);
		int day = int.Parse(date [0]);
		int hh = int.Parse(hour [0]);
		int minute = int.Parse(hour [1]);
		return new DateTime (year, month, day, hh, minute, 0);
	}


	private Vector2 GetAnnotation ()
	{
		string ubicationText = ubicationField.text;
		string[] coordinates = ubicationText.Split (new string[1]{" , "}, StringSplitOptions.None);
		return new Vector2 (float.Parse(coordinates[0]), float.Parse(coordinates[1]));
	}

	public static int ConvertToUnixTimestamp(DateTime date)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		TimeSpan diff = date.ToUniversalTime() - origin;
		Debug.Log ((int)diff.TotalSeconds);
		return (int)diff.TotalSeconds;
	}


}
