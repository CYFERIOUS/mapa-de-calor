using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ReportSaver {

	private int timeStamp;
	private string userName;
	private Vector2 location;
	private Robbery robbery;
	private string article;
	private string comments;

	public ReportSaver(){

		location = new Vector2();
		robbery = Robbery.non_specified;
	
	}

	public Vector2 getLocation() {
		return this.location;
	}

	public Robbery getRobbery() {
		return this.robbery;
	}

	private void saverPrefs(){

		PlayerPrefs.SetInt("time", timeStamp);
		PlayerPrefs.SetString("user", userName);
		PlayerPrefs.SetFloat ("locationx", location.x);
		PlayerPrefs.SetFloat ("locationy", location.y);
		//PlayerPrefs.SetString ("robbing", robbery);
		PlayerPrefs.SetString ("stuff", article);
		PlayerPrefs.SetString ("description", comments);
	}

	private void loadPrefs(){
		
		PlayerPrefs.GetInt("time", timeStamp);
		PlayerPrefs.GetString("user", userName);
		PlayerPrefs.GetFloat ("locationx", location.x);
		PlayerPrefs.GetFloat ("locationy", location.y);
		//PlayerPrefs.GetString ("robbing", robbery);
		PlayerPrefs.GetString ("stuff", article);
		PlayerPrefs.GetString ("description", comments);
	}

}

	
public enum Robbery{
	non_specified,
	Assault,
	Thievery
}

