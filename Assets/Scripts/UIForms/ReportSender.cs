using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[IntegrationTest.DynamicTest ("ReportSenderTests")]
public class ReportSender: MonoBehaviour {

	public InputField Crime;
	//public Button Accept&SaveButton;

	// Use this for initialization
	void Start () {
		IntegrationTest.Pass (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetCrimeIpunt(){
		Debug.Log (Crime.text);
		return Crime.text;
	}
}
