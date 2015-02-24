using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class OpenMapWrapper : MonoBehaviour, MapWrapper
{
	public TestMap testMap;

	public Dictionary<string, double> GetCursorCoordinates ()
	{
		return testMap.GetCoordinatesOfCursor();
	
	}

	public void SetMarkerInMap(){
		Debug.Log ("Click en la clase del wrapper");
		Dictionary<string, double> CursorCoordinates = GetCursorCoordinates ();
		testMap.CreateAnnotationOnClick(CursorCoordinates["latitude"], CursorCoordinates["longitude"]);

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
