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
			ClearReportInput();
		});
	}

	private void HandleSubmitClicked ()
	{
		FormData formdata = CreateFormData ();
		ReportSaver saver = new ReportSaver();
		saver.SetStorage (AppConfig.GetStorage());
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
		int year = 1990, month = 1, day = 1;
		try {
			year = int.Parse(date [2]);
			month = int.Parse(date [1]);
			day = int.Parse(date [0]);
			dateField.image.color = Color.white;
		} catch(Exception e) {
			dateField.image.color = Color.red;
		}
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
	
	public void ClearReportInput(){
		ubicationField.text = "";
		commentsField.text = "";
		dateField.text = "";
		hourField.text = "";
	}
}
public class AppConfig{
	
	static public IDataStorage GetStorage(){
		return new PlayerPrefStorage();
	}
}
