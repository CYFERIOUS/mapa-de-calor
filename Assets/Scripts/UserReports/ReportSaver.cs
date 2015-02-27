using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ReportSaver : IFormDataSaver {

	private IDataStorage storage;
	private Vector2 coordinates;

	void SetStorage(IDataStorage storage) {
		this.storage = storage;
	}

	void Save(FormData data) {
		PlayerPrefs.SetInt("time", data.timestamp);
		PlayerPrefs.SetString("user", data.name);
	}

	/*
	private int timeStamp;																																								
	private string userName;
	private Vector2 location;
	private Robbery robbery;
	private string article;
	private string comments;

	public ReportSaver(){

		location = new Vector2();
		robbery = Robbery.NonSpecified;
	
	}

	public Vector2 getLocation() {
		return this.location;
	}

	public Robbery getRobbery() {
		return this.robbery;
	}

	public int getTimeStamp(){
		return this.timeStamp;
	}

	public string getUserName(){
		return this.userName;
	}

	public string getArticle(){
		return this.article;
	}

	public string getComments(){
		return this.comments;
	}

	public void setLocation(Vector2 location) {
		this.location = location;
	}
	
	public void setRobbery(Robbery robbery) {
		this.robbery = robbery;
	}
	
	public void setTimeStamp(int timeStamp){
		this.timeStamp = timeStamp;
	}
	
	public void setUserName(string userName){
		this.userName = userName;
	}
	
	public void setArticle(string article){
		this.article = article;
	}
	
	public void setComments(string comments){
		this.comments = comments;
	}

	public void save(){
		PlayerPrefs.SetInt("time", timeStamp);
		PlayerPrefs.SetString("user", userName);
		PlayerPrefs.SetFloat ("locationx", location.x);
		PlayerPrefs.SetFloat ("locationy", location.y);
		PlayerPrefs.SetInt ("robbing", (int)robbery);
		PlayerPrefs.SetString ("stuff", article);
		PlayerPrefs.SetString ("description", comments);
		PlayerPrefs.Save ();
	}

	public void load(){
		this.setTimeStamp(PlayerPrefs.GetInt("time"));
		this.setUserName(PlayerPrefs.GetString("user"));
		this.setArticle(PlayerPrefs.GetString ("stuff"));
		this.setComments(PlayerPrefs.GetString ("description"));
		this.setRobbery((Robbery)PlayerPrefs.GetInt ("robbing"));
		Vector2 loc = new Vector2 ();
		loc.x = PlayerPrefs.GetFloat ("locationx", location.x);
		loc.y = PlayerPrefs.GetFloat ("locationy", location.y);
		this.setLocation(loc);
	}*/

}

	
public enum Robbery{
	NonSpecified,
	Assault,
	Thievery
}

