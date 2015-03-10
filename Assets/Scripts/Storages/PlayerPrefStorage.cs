using UnityEngine;
using System.Collections;

public class PlayerPrefStorage : IDataStorage {
	
	public string GetName(){
		return PlayerPrefs.GetString("user");
	}
	public string GetComments(){
		return PlayerPrefs.GetString ("description"); 
	}
	public Vector2 GetAnnotation(){
		Vector2 loc = new Vector2 ();
		loc.x = PlayerPrefs.GetFloat ("locationx", loc.x);
		loc.y = PlayerPrefs.GetFloat ("locationy", loc.y);
		return loc;
	}
	public int GetTimestamp(){
		return PlayerPrefs.GetInt("time");
	}
	public string GetStuff(){
		return PlayerPrefs.GetString ("stuff");
	}
	
	public int GetOcurrence() {
		return PlayerPrefs.GetInt ("ocurrence");
	}
	
	public void SetName(string val){
		PlayerPrefs.SetString("user", val);
	}
	public void SetComments(string val){
		PlayerPrefs.SetString ("description", val);
	}
	
	public void SetAnnotation(Vector2 val){
		PlayerPrefs.SetFloat ("locationx", val.x);
		PlayerPrefs.SetFloat ("locationy", val.y);
	}
	
	public void SetTimestamp(int val){
		PlayerPrefs.SetInt("time", val);
	}
	
	public void SetStuff(string val){
		PlayerPrefs.SetString ("stuff", val);
	}
	
	public void SetOcurrence(int val) {
		PlayerPrefs.SetInt ("ocurrence", val);
	}
	public void save(){
		PlayerPrefs.Save ();
	}

}
