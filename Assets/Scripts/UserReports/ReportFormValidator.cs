using UnityEngine;
using System;
using System.Collections;

public class ReportFormValidator  {

	private int day;

	public bool IsValid {
		get{
			const int FIRST_DAY_OF_MONTH = 1;
			const int LAST_DAY_OF_MONTH = 31;
			return day>=FIRST_DAY_OF_MONTH && day<=LAST_DAY_OF_MONTH;
		}
	}

	public string Day {
		set {
			int intValue = 0;
			try{
				intValue = int.Parse(value);
			}
			catch(Exception e){}
			day = intValue;
		}
	}

}
