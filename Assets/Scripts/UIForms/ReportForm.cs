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
	private Color defaultInputColor = new Color (0.41f,0.92f,0.77f);
	private Color wrongInputColor=new Color(0.9f,0.6f,0.6f,0.8f);

	public void Start()
	{
		validator = new ReportFormValidator ();
	}

	public void Validate() {
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
			dayInput.image.color =defaultInputColor;
		else
			dayInput.image.color = wrongInputColor;
			
	}

	void MonthInputFieldColorChanger ()
	{
		validator.Month = monthInput.text;
		if (validator.IsValidMonth())
			monthInput.image.color = defaultInputColor;
		else
			monthInput.image.color = wrongInputColor;
	}

	void YearInputFieldColorChanger ()
	{
		validator.Year = yearInput.text;
		if (validator.IsValidYear())
			yearInput.image.color = defaultInputColor;
		else
			yearInput.image.color = wrongInputColor;

	}

	void HourInputFieldColorChanger ()
	{
		validator.Hour = hourInput.text;
		if (validator.IsValidHour())
			hourInput.image.color = defaultInputColor;
		else
			hourInput.image.color = wrongInputColor;
	}

	void MinuteInputFieldColorChanger ()
	{
		validator.Minute = minuteInput.text;
		if (validator.IsValidMinute())
			minuteInput.image.color = defaultInputColor;
		else
			minuteInput.image.color = wrongInputColor;
	}

	void CommentsInputFieldColorChanger ()
	{
		validator.Comments = commentsInput.text;
		if (validator.IsValidComment())
			commentsInput.image.color = defaultInputColor;
		else
			commentsInput.image.color = wrongInputColor;
	}

	public void ReportCleaner(){
		dayInput.image.color = defaultInputColor;
		monthInput.image.color = defaultInputColor;
		yearInput.image.color = defaultInputColor;
		hourInput.image.color = defaultInputColor;
		minuteInput.image.color = defaultInputColor;
		commentsInput.image.color = defaultInputColor;
	}
}