using UnityEngine;
using System.Collections;

public class DataStorageMock : IDataStorage {

	private string name;
	private string comments;
	private Vector2 coordinates;
	private int timeStamp;
	private string stuff;
	private int robbery;

	public string GetName(){
		return name; 
	}
	public string GetComments(){
		return comments; 
	}
	public Vector2 GetAnnotation(){
		return coordinates;
	}
	public int GetTimestamp(){
		return timeStamp;
	}
	public string GetStuff(){
		return stuff;
	}

	public int GetRobbery() {
		return robbery;
	}

	public void SetName(string val){
		name = val;
	}
	public void SetComments(string val){
		comments = val;
	}

	public void SetAnnotation(Vector2 val){
		coordinates = val;
	}

	public void SetTimestamp(int val){
		timeStamp = val;
	}

	public void SetStuff(string val){
		stuff = val;
	}

	public void SetRobbery(int val) {
		robbery = val;
	}

}
