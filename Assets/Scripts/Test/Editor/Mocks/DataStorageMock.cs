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

	public string GetName(int k){
		FormData form = search ();
		return (form.key == -1)? null : form.name;
	}
	public string GetComments(int k){
		FormData form = search ();
		return (form.key == -1)? null : form.comments;
	}
	public Vector2 GetAnnotation(int k){
		FormData form = search ();
		return (form.key == -1)? new Vector2() : form.annotation;
	}
	public int GetTimestamp(int k){
		FormData form = search ();
		return (form.key == -1)? 0 : form.timestamp;
	}
	public string GetStuff(int k){
		FormData form = search ();
		return (form.key == -1)? null : form.stuff;
	}

	public int GetOcurrence(int k) {
		FormData form = search ();
		return (form.key == -1)? 0 : form.ocurrence;
	}

	public int GetTotalKey(){
		return total;
	}

	public void SetName(int k, string val){
		name = val;
	}

	public void SetKey(int k, int val){
		key = val;
	}

	public void SetComments(int k, string val){
		comments = val;
	}

	public void SetAnnotation(int k, Vector2 val){
		coordinates = val;
	}

	public void SetTimestamp(int k, int val){
		timeStamp = val;
	}

	public void SetStuff(int k, string val){
		stuff = val;
	}

	public void SetOcurrence(int k, int val) {
		ocurrence = val;
	}
	public void SetTotalKey(int val) {
		total = val;
	}

}
