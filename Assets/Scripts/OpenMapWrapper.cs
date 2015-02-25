using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnitySlippyMap;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.Converters.WellKnownText;

public class OpenMapWrapper : MonoBehaviour, MapWrapper
{
	//public TestMap testMap;
	public InputField DirectionInputField;
	public Texture	LocationTexture;
	public Texture	MarkerTexture;
	private GameObject go;
	private Map		map;
	private List<Layer> layers;
	private Ray pulsacion;
	private RaycastHit colision;
	private bool isMarkerSet;

	public Dictionary<string, double> GetCursorCoordinates ()
	{
		return GetCoordinatesOfCursor ();
	
	}

	public void SetMarkerInMap ()
	{
		if (isMarkerSet == false) {
			Debug.Log ("Click en la clase del wrapper");
			Dictionary<string, double> CursorCoordinates = GetCursorCoordinates ();
			CreateAnnotation (CursorCoordinates ["latitude"], CursorCoordinates ["longitude"]);
			SetCoordinatesOnInputField (CursorCoordinates ["latitude"], CursorCoordinates ["longitude"]);
		}
		isMarkerSet = true;
	}

	public void SetCoordinatesOnInputField (double latitude, double longitude)
	{
		DirectionInputField.text = latitude.ToString () + " , " + longitude.ToString ();
	}

	public void SetToFalseIsMarkerSet ()
	{
		isMarkerSet = false;
	}

	public void DetectDoubleTap ()
	{
		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				if (Input.GetTouch (i).tapCount == 2) {
					SetMarkerInMap ();
				}
			}
		}
	}

	// Use this for initialization
	void Start ()
	{
		SetupMapInstance ();
		SetupVirtualEarthLayer ();
		DrawGPSUserLocation ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DetectDoubleTap ();
	}

	public void SetupVirtualEarthLayer(){
		layers = new List<Layer> ();
		
		// create a VirtualEarth tile layer
		VirtualEarthTileLayer virtualEarthLayer = map.CreateLayer<VirtualEarthTileLayer> ("VirtualEarth");
		virtualEarthLayer.Key = "Ag-ML2n_NjUqTCNOJyd9Yyr-GRfEWVmY_yboAe3A3aUL2JrE1d9er914Tfs9kgrp";
		
		virtualEarthLayer.gameObject.SetActive (true);
		
		layers.Add (virtualEarthLayer);
		
	}
	
	public void SetupMapInstance ()
	{
		// create the map singleton
		map = Map.Instance;
		map.CurrentCamera = Camera.main;
		map.InputDelegate += UnitySlippyMap.Input.MapInput.BasicTouchAndKeyboard;
		map.CurrentZoom = 15.0f;
		map.CenterWGS84 = new double[2] { -74.084046, 4.638194 };
		map.UseLocation = true;
		map.InputsEnabled = true;
		map.ShowGUIControls = false;
		
		
	}
	
	public Dictionary<string, double> GetCoordinatesOfCursor ()
	{
		Dictionary<string, double> dictionary = new Dictionary<string, double> ();
		
		Vector3 wordPos = getCursorPosition ();
		
		double latitude = (0.0167 * wordPos [2]) + ((map.CenterWGS84) [1]);
		double longitude = (0.0167 * wordPos [0]) + ((map.CenterWGS84) [0]);
		dictionary.Add ("latitude", latitude);
		dictionary.Add ("longitude", longitude);
		return dictionary;
		
	}
	
	public Vector3 getCursorPosition ()
	{
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
		Ray ray = Camera.main.ScreenPointToRay (mousePos);
		RaycastHit hit;
		
		Vector3 wordPos;
		if (Physics.Raycast (ray, out hit, 1000f)) {
			
			wordPos = hit.point;
			
		} else {
			
			wordPos = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position);
		}
		
		return wordPos;
	}
	
	public void DrawGPSUserLocation ()
	{
		GameObject markerGO = CreateMarkerGameObject(Tile.AnchorPoint.MiddleCenter, LocationTexture, 4001, new Vector3 (1.0f, 1.0f, 1.0f)/27);
		map.SetLocationMarker<LocationMarker> (markerGO);
		DestroyImmediate (go);
	}
	
	public void CreateAnnotation (double latitude, double longitude)
	{
		GameObject markerGO = CreateMarkerGameObject(Tile.AnchorPoint.BottomCenter, MarkerTexture, 4000, new Vector3 (0.7f, 1.0f, 1.0f)/7);
		map.CreateMarker<Marker> ("test marker - 9 rue Gentil, Lyon", new double[2] {
			longitude,
			latitude
		}, markerGO);
		DestroyImmediate (go);
		
	}
	
	public GameObject CreateMarkerGameObject(Tile.AnchorPoint anchorPoint, Texture mainTexture, int renderQueue, Vector3 localScale){
		go = Tile.CreateTileTemplate (anchorPoint).gameObject;
		go.renderer.material.mainTexture = mainTexture;
		go.renderer.material.renderQueue = renderQueue;
		go.transform.localScale = localScale;
		GameObject markerGO = Instantiate (go) as GameObject;
		return markerGO;
		
	}


}
