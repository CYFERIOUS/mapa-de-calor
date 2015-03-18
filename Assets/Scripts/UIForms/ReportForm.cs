using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReportForm : MonoBehaviour {
	public InputField dayInput;
	public InputField monthInput;
	public InputField yearInput;
	public InputField hourInput;
	public InputField minuteInput;
	public InputField commentsInput;
	private ReportFormValidator validator;
	private Color wrongInputColor=new Color(0.9f,0.6f,0.6f,0.8f);

	public void Start()
	{
		validator = new ReportFormValidator ();
	}

	public void Update() {
		DayInputFieldColorChanger();
		MonthInputFieldColorChanger();
		YearInputFieldColorChanger();
		HourInputFieldColorChanger();
		MinuteInputFieldColorChanger();
		CommentsInputFieldColorChanger();
	}

	void DayInputFieldColorChanger ()
	{
		validator.Day = dayInput.text;
		if (validator.IsValidDay())
			dayInput.image.color = Color.white;
		else
			dayInput.image.color = wrongInputColor;
			
	}

	void MonthInputFieldColorChanger ()
	{
		validator.Month = monthInput.text;
		if (validator.IsValidMonth())
			monthInput.image.color = Color.white;
		else
			monthInput.image.color = wrongInputColor;
	}

	void YearInputFieldColorChanger ()
	{
		validator.Year = yearInput.text;
		if (validator.IsValidYear())
			yearInput.image.color = Color.white;
		else
			yearInput.image.color = wrongInputColor;

	}

	void HourInputFieldColorChanger ()
	{
		validator.Hour = hourInput.text;
		if (validator.IsValidHour())
			hourInput.image.color = Color.white;
		else
			hourInput.image.color = wrongInputColor;
	}

	void MinuteInputFieldColorChanger ()
	{
		validator.Minute = minuteInput.text;
		if (validator.IsValidMinute())
			minuteInput.image.color = Color.white;
		else
			minuteInput.image.color = wrongInputColor;
	}

	void CommentsInputFieldColorChanger ()
	{
		validator.Comments = commentsInput.text;
		if (validator.IsValidComment())
			commentsInput.image.color = Color.white;
		else
			commentsInput.image.color = wrongInputColor;
	}
}