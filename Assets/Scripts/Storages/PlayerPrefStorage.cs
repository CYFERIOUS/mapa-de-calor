using UnityEngine;
using System.Collections;

public class PlayerPrefStorage : IDataStorage {

	public string GetName(int key){
		return PlayerPrefs.GetString("user" + key);
	}
	public string GetComments(int key){
		return PlayerPrefs.GetString ("description" + key); 
	}
	public Vector2 GetAnnotation(int key){
		Vector2 loc = new Vector2 ();
		loc.x = PlayerPrefs.GetFloat ("locationx" + key, loc.x);
		loc.y = PlayerPrefs.GetFloat ("locationy" + key, loc.y);
		return loc;
	}
	public int GetTimestamp(int key){
		return PlayerPrefs.GetInt("time" + key);
	}
	public string GetStuff(int key){
		return PlayerPrefs.GetString ("stuff" + key);
	}
	
	public int GetOcurrence(int key) {
		return PlayerPrefs.GetInt ("ocurrence" + key);
	}

	public void SetName(int key, string val){
		PlayerPrefs.SetString("user" + key, val);

	}

	public int GetTotalKey(){
		return PlayerPrefs.GetInt("TotalKey");
	}

	public void SetComments(int key, string val){
		PlayerPrefs.SetString ("description" + key, val);
	}
	
	public void SetAnnotation(int key, Vector2 val){
		PlayerPrefs.SetFloat ("locationx" + key, val.x);
		PlayerPrefs.SetFloat ("locationy" + key, val.y);
	}
	
	public void SetTimestamp(int key, int val){
		PlayerPrefs.SetInt("time" + key, val);
	}
	
	public void SetStuff(int key, string val){
		PlayerPrefs.SetString ("stuff" + key, val);
	}
	
	public void SetOcurrence(int key, int val) {
		PlayerPrefs.SetInt ("ocurrence"+key, val);
	}
	public void SetTotalKey(int val){
		PlayerPrefs.SetInt("TotalKey", val);
	}
	public void save(){
		PlayerPrefs.Save ();
	}

}
