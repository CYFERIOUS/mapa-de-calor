using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ReportSaver {

	private int timeStamp;
	private string userName;
	private Vector2 location;
	private int robbery;
	private string article;
	private string comments;

	public ReportSaver(){

		location = new Vector2();
		robbery = (int)Robbery.non_specified;
	
	}

	public Vector2 getLocation() {
		return this.location;
	}

	public int getRobbery() {
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
	
	public void setRobbery(int robbery) {
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
		PlayerPrefs.SetInt ("robbing", robbery);
		PlayerPrefs.SetString ("stuff", article);
		PlayerPrefs.SetString ("description", comments);
		PlayerPrefs.Save ();
	}

	public void load(){
		this.setTimeStamp(PlayerPrefs.GetInt("time", timeStamp));
		this.setUserName(PlayerPrefs.GetString("user", userName));
		this.setRobbery(PlayerPrefs.GetInt ("robbing", robbery));
		this.setArticle(PlayerPrefs.GetString ("stuff", article));
		this.setComments(PlayerPrefs.GetString ("description", comments));

		Vector2 loc = new Vector2 ();
		loc.x = PlayerPrefs.GetFloat ("locationx", location.x);
		loc.y = PlayerPrefs.GetFloat ("locationy", location.y);
		this.setLocation(loc);
	}

}

	
public enum Robbery{
	non_specified = 0,
	Assault = 1,
	Thievery = 2
}

