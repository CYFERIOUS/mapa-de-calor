using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Globalization;

public class ReportSender: MonoBehaviour {

	public InputField ubicationField;
	public InputField commentsField;
	public InputField dateField;
	public InputField hourField;
	public Button submitButton;
	public Button cancelButton;

	public GameObject reportWindow;

	void Start(){
		submitButton.onClick.AddListener (delegate {

			if(isValidDate(dateField.text) && isValidHour(hourField.text)){
				resetColorValidation();
				HandleSubmitClicked();
				reportWindow.SetActive(false);
				ClearReportInput();
			}else{
				if(!isValidDate(dateField.text)){
					dateField.image.color = Color.red;
				}
				if(!isValidHour(hourField.text)){
					hourField.image.color = Color.red;
				}
			}

		});

		cancelButton.onClick.AddListener (delegate {
			ClearReportInput();
			resetColorValidation();
		});

		dateField.onValueChange.AddListener (delegate {
			dateField.image.color = Color.white;
		});
		hourField.onValueChange.AddListener (delegate {
			hourField.image.color = Color.white;
		});
	}

	public void resetColorValidation ()
	{
		commentsField.image.color = Color.white;
		dateField.image.color = Color.white;
		hourField.image.color = Color.white;
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

		year = int.Parse(date [2]);
		month = int.Parse(date [1]);
		day = int.Parse(date [0]);

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

	public bool isValidDate(String date){
		string[] formats = {"dd-mm-yyyy"};
		DateTime dateValue;

		if (DateTime.TryParseExact (date, formats, 
           new CultureInfo ("en-US"), 
           DateTimeStyles.None, 
           out dateValue))
			return true;
		return false;
	}

	public bool isValidHour(string hour) {
		try {
			string pattern = "^\\d{2}:\\d{2}$";
			if(System.Text.RegularExpressions.Regex.IsMatch(hour,pattern)) {
				TimeSpan span = TimeSpan.Parse(hour);
				return true;
			}
			return false;
		} catch {
			return false;
		}
	}
}
public class AppConfig{
	
	static public IDataStorage GetStorage(){
		return new PlayerPrefStorage();
	}
}
