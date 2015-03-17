using UnityEngine;
using System;
using System.Collections;

public class ReportFormValidator  {

	private int day;
	private int month;
	private int year;
	private int hour;
	private int minute;
	private string comments;

	private const int FIRST_DATE_NUMBER_VALID=1;
	private const int FIRST_TIME_NUMBER_VALID = 0;

	public bool IsValidDay() {
		const int LAST_DAY_OF_MONTH = 31;
		return (day>=FIRST_DATE_NUMBER_VALID && day<=LAST_DAY_OF_MONTH);
		}

	public bool IsValidMonth(){
		const int LAST_MONTH_OF_YEAR=12;
		return (month>=FIRST_DATE_NUMBER_VALID && month<=LAST_MONTH_OF_YEAR);
	}

	public bool IsValidHour ()
	{
		const int LAST_HOUR_OF_DAY=23;
		return (hour>=FIRST_TIME_NUMBER_VALID && hour<=LAST_HOUR_OF_DAY);
	}	

	public bool IsValidYear ()
	{
		const int LIMIT_YEAR = 9999;
		return (year>=FIRST_TIME_NUMBER_VALID && year<=LIMIT_YEAR);
	}	

	public bool IsValidMinute ()
	{
		const int LAST_MINUTE_OF_HOUR=59;
		return (minute>=FIRST_TIME_NUMBER_VALID && minute<=LAST_MINUTE_OF_HOUR);
	}	
	public bool IsValidComment ()
	{
		return (comments!=""?true:false);
	}

	public string Day {
		set {

			day = DateToIntConverter(value);
		}
	}

	public string Month{
		set{
			month=DateToIntConverter(value);
		}
	}

	public string Year {
		set{
			year=DateToIntConverter(value);
		}
	}

	public string Hour {
		set{
			hour=DateToIntConverter(value);
		}
	}

	public string Minute {
		set{
			minute=DateToIntConverter(value);
		}
	}

	public string Comments {
		set{
			comments=value;
		}
	}
	
	public int DateToIntConverter(string value){
		int intValue = -1;
		try{
			return intValue = int.Parse(value);

		}
		catch(Exception e){}
		return intValue;
	}

}
