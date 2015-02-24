using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OpenMapWrapper : MonoBehaviour, MapWrapper
{
	public TestMap testMap;
	public InputField DirectionInputField;

	public Dictionary<string, double> GetCursorCoordinates ()
	{
		return testMap.GetCoordinatesOfCursor();
	
	}

	public void SetMarkerInMap(){
		Debug.Log ("Click en la clase del wrapper");
		Dictionary<string, double> CursorCoordinates = GetCursorCoordinates ();
		testMap.CreateAnnotationOnClick(CursorCoordinates["latitude"], CursorCoordinates["longitude"]);
		SetCoordinatesOnInputField (CursorCoordinates["latitude"],CursorCoordinates["longitude"]);
	}

	public void SetCoordinatesOnInputField(double latitude, double longitude){
		DirectionInputField.text = latitude.ToString () + " , " + longitude.ToString ();
	}
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

		
	}


}
