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
		CallData();
		ExtractInfo();
	}

	void CallData(){
		loader = new ReportLoader();
		dataPerUser = new FormData();
		loader.SetStorage(CallerData.GetStorage());
		dataPerUser = loader.Load(1);
	}

	public void ExtractInfo(){
		userName.text = "User";
		//userDate.text = dataPerUser.timestamp.ToString();
		userDate.text = (ConvertFromUnixTimestamp(dataPerUser.timestamp)).ToString();
		userHour.text =  dataPerUser.timestamp.ToString();
		userComments.text =  dataPerUser.comments;
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
