using UnityEngine;
using System.Collections;

public class LogStorage : IDataStorage {
	
	public string GetName(){
		return "name";
	}
	public int GetKey(){
		return 1;
	}
	public string GetComments(){
		return "comments"; 
	}
	public Vector2 GetAnnotation(){
		return new Vector2 ();
	}
	public int GetTimestamp(){
		return 0;
	}
	public string GetStuff(){
		return "stuff";
	}
	
	public int GetOcurrence() {
		return 0;
	}

	public int GetTotalKey() {
		return 0;
	}


	public void SetName(string val){
		Debug.Log ("Name: "+val);
	}

	public void SetKey(int val){
		Debug.Log ("ReportNumber: "+val);
	}

	public void SetComments(string val){
		Debug.Log ("comments: "+val);
	}
	
	public void SetAnnotation(Vector2 val){
		Debug.Log ("val: "+val.ToString());
	}
	
	public void SetTimestamp(int val){
		Debug.Log ("time: "+val);
	}
	
	public void SetStuff(string val){
		Debug.Log ("stuff: "+val);
	}
	
	public void SetOcurrence(int val) {
		Debug.Log ("occurrence: "+val);
	}

	public void SetTotalKey(int val) {
		Debug.Log ("TotalKeys: "+val);
	}

	public void save(){
		Debug.Log ("save");
	}
}


