using UnityEngine;
using UnityEngine.UI;
using System;

public class ReportView: MonoBehaviour {

	private ReportLoader loader;
	private FormData dataPerUser;
	private GameObject reportView;
	DateTime date1 = DateTime.Now;

	public Text userName;
	public Text userDate;
	public Text userHour;
	public  Text userComments;

	void Start(){

	}

	public void CallData(int key) {
		loader = new ReportLoader();
		dataPerUser = new FormData();
		loader.SetStorage(CallerData.GetStorage());
		dataPerUser = loader.Load(key);
		ExtractInfo();
	}

	public void ExtractInfo(){

		userComments.text =  dataPerUser.comments;
		userName.text = "User";

		string timeData = (ConvertFromUnixTimestamp(dataPerUser.timestamp)).ToString();
		string[] words =  timeData.Split(' ');

		foreach (string s in words) {
		
			userDate.text  = words[0];
			userHour.text =  words[1];
		}


	}

	public  DateTime ConvertFromUnixTimestamp(double timestamp)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return origin.AddSeconds(timestamp);
	}
}
public class CallerData{
	
	static public IDataStorage GetStorage(){
		return new PlayerPrefStorage();
	}
}
