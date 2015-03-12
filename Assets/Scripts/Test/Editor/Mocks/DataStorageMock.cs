using UnityEngine;
using System.Collections;

public class DataStorageMock : IDataStorage {

	private string name;
	private int key;
	private string comments;
	private Vector2 coordinates;
	private int timeStamp;
	private string stuff;
	private int ocurrence;
	private ArrayList data = new ArrayList();
	private int total;

	public FormData search() {
		FormData form = new FormData();
		form.key = -1;
		foreach (FormData frm in data)
			if (frm.key == key)
				form = frm;
		return form;
	}

	public void save(){
		FormData form = search ();

		form.name = name;
		form.comments = comments;
		form.annotation = coordinates;
		form.timestamp = timeStamp;
		form.ocurrence = ocurrence;
		form.stuff = stuff;
		
		if (form.key == -1) {
			form.key = key;
			data.Add (form);
		} else
			form.key = key;
	}

	public string GetName(){
		FormData form = search ();
		return (form.key == -1)? null : form.name;
	}
	public int GetKey(){
		return key;
	}
	public string GetComments(){
		FormData form = search ();
		return (form.key == -1)? null : form.comments;
	}
	public Vector2 GetAnnotation(){
		FormData form = search ();
		return (form.key == -1)? new Vector2() : form.annotation;
	}
	public int GetTimestamp(){
		FormData form = search ();
		return (form.key == -1)? 0 : form.timestamp;
	}
	public string GetStuff(){
		FormData form = search ();
		return (form.key == -1)? null : form.stuff;
	}

	public int GetOcurrence() {
		FormData form = search ();
		return (form.key == -1)? 0 : form.ocurrence;
	}

	public int GetTotalKey(){
		return total;
	}

	public void SetName(string val){
		name = val;
	}

	public void SetKey(int val){
		key = val;
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

	public void SetOcurrence(int val) {
		ocurrence = val;
	}
	public void SetTotalKey(int val) {
		total = val;
	}

}
