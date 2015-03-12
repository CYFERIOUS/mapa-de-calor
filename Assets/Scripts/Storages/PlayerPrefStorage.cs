using UnityEngine;
using System.Collections;

public class PlayerPrefStorage : IDataStorage {

	private int key = -1;

	public string GetName(){
		return PlayerPrefs.GetString("user" + key);
	}
	public int GetKey(){
		return key;
	}
	public string GetComments(){
		return PlayerPrefs.GetString ("description" + key); 
	}
	public Vector2 GetAnnotation(){
		Vector2 loc = new Vector2 ();
		loc.x = PlayerPrefs.GetFloat ("locationx" + key, loc.x);
		loc.y = PlayerPrefs.GetFloat ("locationy" + key, loc.y);
		return loc;
	}
	public int GetTimestamp(){
		return PlayerPrefs.GetInt("time" + key);
	}
	public string GetStuff(){
		return PlayerPrefs.GetString ("stuff" + key);
	}
	
	public int GetOcurrence() {
		return PlayerPrefs.GetInt ("ocurrence" + key);
	}

	public void SetName(string val){
		PlayerPrefs.SetString("user" + key, val);

	}
	public void SetKey(int val){
		key = val;
	}
	public int GetTotalKey(){
		return PlayerPrefs.GetInt("TotalKey");
	}

	public void SetComments(string val){
		PlayerPrefs.SetString ("description" + key, val);
	}
	
	public void SetAnnotation(Vector2 val){
		PlayerPrefs.SetFloat ("locationx" + key, val.x);
		PlayerPrefs.SetFloat ("locationy" + key, val.y);
	}
	
	public void SetTimestamp(int val){
		PlayerPrefs.SetInt("time" + key, val);
	}
	
	public void SetStuff(string val){
		PlayerPrefs.SetString ("stuff" + key, val);
	}
	
	public void SetOcurrence(int val) {
		PlayerPrefs.SetInt ("ocurrence"+key, val);
	}
	public void SetTotalKey(int val){
		PlayerPrefs.SetInt("TotalKey", val);
	}
	public void save(){
		PlayerPrefs.Save ();
	}

}
