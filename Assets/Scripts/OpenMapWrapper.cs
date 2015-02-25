using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;


public class OpenMapWrapper : MonoBehaviour, MapWrapper
{
	public TestMap testMap;
	public InputField DirectionInputField;
	private bool isMarkerSet;

	public Dictionary<string, double> GetCursorCoordinates ()
	{
		return testMap.GetCoordinatesOfCursor();
	
	}

	public void SetMarkerInMap(){
		if(isMarkerSet==false){
			Debug.Log ("Click en la clase del wrapper");
			Dictionary<string, double> CursorCoordinates = GetCursorCoordinates ();
			testMap.CreateAnnotationOnClick(CursorCoordinates["latitude"], CursorCoordinates["longitude"]);
			SetCoordinatesOnInputField (CursorCoordinates["latitude"],CursorCoordinates["longitude"]);
		}
		isMarkerSet = true;
	}

	public void SetCoordinatesOnInputField(double latitude, double longitude){
		DirectionInputField.text = latitude.ToString () + " , " + longitude.ToString ();
	}

	public void SetToFalseIsMarkerSet(){
		isMarkerSet = false;
	}

	public void DetectDoubleTap(){
		for (var i = 0; i < Input.touchCount; ++i)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began) 
			{
				if(Input.GetTouch(i).tapCount == 2)
				{
					SetMarkerInMap();
				}
			}
		}
	}

	// Use this for initialization
	void Start ()
	{
testMap.SetupMapInstance ();
testMap.SetupVirtualEarthLayer ();
		testMap.DrawGPSUserLocation ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DetectDoubleTap ();
	}


}
