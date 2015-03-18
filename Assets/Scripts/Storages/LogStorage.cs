using UnityEngine;
using System.Collections;

public class LogStorage : IDataStorage {
	
	public string GetName(int key){
		return "name";
	}
	public string GetComments(int key){
		return "comments"; 
	}
	public Vector2 GetAnnotation(int key){
		return new Vector2 ();
	}
	public int GetTimestamp(int key){
		return 0;
	}
	public string GetStuff(int key){
		return "stuff";
	}
	
	public int GetOcurrence(int key) {
		return 0;
	}

	public int GetTotalKey() {
		return 0;
	}


	public void SetName(int key, string val){
		Debug.Log ("Name: "+val);
	}

	public void SetKey(int key, int val){
		Debug.Log ("ReportNumber: "+val);
	}

	public void SetComments(int key, string val){
		Debug.Log ("comments: "+val);
	}
	
	public void SetAnnotation(int key, Vector2 val){
		Debug.Log ("val: "+val.ToString());
	}
	
	public void SetTimestamp(int key, int val){
		Debug.Log ("time: "+val);
	}
	
	public void SetStuff(int key, string val){
		Debug.Log ("stuff: "+val);
	}
	
	public void SetOcurrence(int key, int val) {
		Debug.Log ("occurrence: "+val);
	}

	public void SetTotalKey(int val) {
		Debug.Log ("TotalKeys: "+val);
	}

	public void save(){
		Debug.Log ("save");
	}
}


