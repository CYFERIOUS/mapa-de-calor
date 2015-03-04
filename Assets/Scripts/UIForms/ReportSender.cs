using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ReportSender: MonoBehaviour {

	public InputField place;


	public ReportSaver saver;
	private FormData data = new FormData ();

	// Use this for initialization
	void Start () {
		data.comments = place.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetPlaceIpunt(){
		Debug.Log (place.text);
		return place.text;
	}
}
