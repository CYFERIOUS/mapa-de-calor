using UnityEngine;
using System.Collections;

public class ReportFormValidator  {

	public bool IsValid {
		get{
			const int FIRST_DAY_OF_MONTH = 1;
			const int LAST_DAY_OF_MONTH = 31;
			return Day>=1 && Day<=31;
		}
	}

	public int Day {
		get;
		set;	
	}

}
