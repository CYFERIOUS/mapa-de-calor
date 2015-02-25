//  Author:
//       Jonathan Derrough <jonathan.derrough@gmail.com>
//  
//  Copyright (c) 2012 Jonathan Derrough
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using UnityEngine;

using System;
using UnityEngine.UI;
using UnitySlippyMap;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.Converters.WellKnownText;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class TestMap : MonoBehaviour
{
	private Map		map;
	
	public Texture	LocationTexture;
	public Texture	MarkerTexture;
	
	public Text CoordinatesText;

	
	private float	guiXScale;
	private float	guiYScale;
	private Rect	guiRect;
	
	private bool 	isPerspectiveView = false;
	private float	perspectiveAngle = 30.0f;
	private float	destinationAngle = 0.0f;
	private float	currentAngle = 0.0f;
	private float	animationDuration = 0.5f;
	private float	animationStartTime = 0.0f;
	
	private List<Layer> layers;
	private int     currentLayerIndex = 0;
	
	
	private Ray pulsacion;
	private RaycastHit colision;
	
	public GameObject go;
	
	
	
	bool Toolbar(Map map)
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3(guiXScale, guiXScale, 1.0f));
		
		GUILayout.BeginArea(guiRect);
		
		GUILayout.BeginHorizontal();
		
		//GUILayout.Label("Zoom: " + map.CurrentZoom);
		
		bool pressed = false;
		if (GUILayout.RepeatButton("+", GUILayout.ExpandHeight(true)))
		{
			map.Zoom(1.0f);
			pressed = true;
		}
		if (Event.current.type == EventType.Repaint)
		{
			Rect rect = GUILayoutUtility.GetLastRect();
			if (rect.Contains(Event.current.mousePosition))
				pressed = true;
		}
		
		if (GUILayout.Button("2D/3D", GUILayout.ExpandHeight(true)))
		{
			if (isPerspectiveView)
			{
				destinationAngle = -perspectiveAngle;
			}
			else
			{
				destinationAngle = perspectiveAngle;
			}
			
			animationStartTime = Time.time;
			
			isPerspectiveView = !isPerspectiveView;
		}
		if (Event.current.type == EventType.Repaint)
		{
			Rect rect = GUILayoutUtility.GetLastRect();
			if (rect.Contains(Event.current.mousePosition))
				pressed = true;
		}
		
		if (GUILayout.Button("Center", GUILayout.ExpandHeight(true)))
		{
			map.CenterOnLocation();
		}
		if (Event.current.type == EventType.Repaint)
		{
			Rect rect = GUILayoutUtility.GetLastRect();
			if (rect.Contains(Event.current.mousePosition))
				pressed = true;
		}
		
		string layerMessage = String.Empty;
		if (map.CurrentZoom > layers[currentLayerIndex].MaxZoom)
			layerMessage = "\nZoom out!";
		else if (map.CurrentZoom < layers[currentLayerIndex].MinZoom)
			layerMessage = "\nZoom in!";
		if (GUILayout.Button(((layers != null && currentLayerIndex < layers.Count) ? layers[currentLayerIndex].name + layerMessage : "Layer"), GUILayout.ExpandHeight(true)))
		{
			#if UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6 || UNITY_3_7 || UNITY_3_8 || UNITY_3_9
			layers[currentLayerIndex].gameObject.SetActiveRecursively(false);
			#else
			layers[currentLayerIndex].gameObject.SetActive(false);
			#endif
			++currentLayerIndex;
			if (currentLayerIndex >= layers.Count)
				currentLayerIndex = 0;
			#if UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6 || UNITY_3_7 || UNITY_3_8 || UNITY_3_9
			layers[currentLayerIndex].gameObject.SetActiveRecursively(true);
			#else
			layers[currentLayerIndex].gameObject.SetActive(true);
			#endif
			map.IsDirty = true;
		}
		
		if (GUILayout.RepeatButton("-", GUILayout.ExpandHeight(true)))
		{
			map.Zoom(-1.0f);
			pressed = true;
		}
		if (Event.current.type == EventType.Repaint)
		{
			Rect rect = GUILayoutUtility.GetLastRect();
			if (rect.Contains(Event.current.mousePosition))
				pressed = true;
		}
		
		GUILayout.EndHorizontal();
		
		GUILayout.EndArea();
		
		return pressed;
	}
	
	private void
		Start()
	{
		//gameObject texto=GameObject
		//CoordinatesText=gameObject.GetComponent<Text>();
		// setup the gui scale according to the screen resolution
		guiXScale = (Screen.orientation == ScreenOrientation.Landscape ? Screen.width : Screen.height) / 480.0f;
		guiYScale = (Screen.orientation == ScreenOrientation.Landscape ? Screen.height : Screen.width) / 640.0f;
		// setup the gui area
		guiRect = new Rect(16.0f * guiXScale, 4.0f * guiXScale, Screen.width / guiXScale - 32.0f * guiXScale, 32.0f * guiYScale);
		
		// create the map singleton
		map = Map.Instance;
		map.CurrentCamera = Camera.main;
		map.InputDelegate += UnitySlippyMap.Input.MapInput.BasicTouchAndKeyboard;
		map.CurrentZoom = 15.0f;
		// 9 rue Gentil, Lyon
		map.CenterWGS84 = new double[2] { -74.084046, 4.638194 };
		map.UseLocation = true;
		map.InputsEnabled = true;
		map.ShowGUIControls = false;
		
		
		map.GUIDelegate += Toolbar;
		
		layers = new List<Layer>();
		
		// create a VirtualEarth tile layer
		VirtualEarthTileLayer virtualEarthLayer = map.CreateLayer<VirtualEarthTileLayer>("VirtualEarth");
		// Note: this is the key UnitySlippyMap, DO NOT use it for any other purpose than testing
		virtualEarthLayer.Key = "Ag-ML2n_NjUqTCNOJyd9Yyr-GRfEWVmY_yboAe3A3aUL2JrE1d9er914Tfs9kgrp";
		#if UNITY_WEBPLAYER
		virtualEarthLayer.ProxyURL = "http://reallyreallyreal.com/UnitySlippyMap/demo/veproxy.php";
		#endif
		#if UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6 || UNITY_3_7 || UNITY_3_8 || UNITY_3_9
		virtualEarthLayer.gameObject.SetActiveRecursively(false);
		#else
		virtualEarthLayer.gameObject.SetActive(true);
		#endif
		
		layers.Add(virtualEarthLayer);

		DrawGPSUserLocation();
	}
	
	void OnApplicationQuit()
	{
		map = null;
	}
	
	void Update()
	{
		if(map.HasMoved==true){
			//CoordinatesText.text=("la coordenada es: "+ (map.CenterWGS84)[0].ToString()+" , "+(map.CenterWGS84)[1].ToString());
		}

		if (destinationAngle != 0.0f)
		{
			Vector3 cameraLeft = Quaternion.AngleAxis(-90.0f, Camera.main.transform.up) * Camera.main.transform.forward;
			if ((Time.time - animationStartTime) < animationDuration)
			{
				float angle = Mathf.LerpAngle(0.0f, destinationAngle, (Time.time - animationStartTime) / animationDuration);
				Camera.main.transform.RotateAround(Vector3.zero, cameraLeft, angle - currentAngle);
				currentAngle = angle;
			}
			else
			{
				Camera.main.transform.RotateAround(Vector3.zero, cameraLeft, destinationAngle - currentAngle);
				destinationAngle = 0.0f;
				currentAngle = 0.0f;
				map.IsDirty = true;
			}
			
			map.HasMoved = true;
		}
	}

	public Dictionary<string, double> GetCoordinatesOfCursor(){
		Dictionary<string, double> dictionary = new Dictionary<string, double>();
		Vector3 mousePos=new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
		Ray ray=Camera.main.ScreenPointToRay(mousePos);
		RaycastHit hit;
		Vector3 wordPos;
		if(Physics.Raycast(ray,out hit,1000f)) {
			
			wordPos=hit.point;
			
		} else {
			
			wordPos=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		}
		CoordinatesText.text= ("posicion= "+ (wordPos));

		double latitude=(0.0167*wordPos[2])+((map.CenterWGS84)[1]);
		double longitude=(0.0167*wordPos[0])+((map.CenterWGS84)[0]);

		dictionary.Add ("latitude", latitude);
		dictionary.Add ("longitude", longitude);

		return dictionary;
	
	}

	public void DrawGPSUserLocation(){
		go = Tile.CreateTileTemplate().gameObject;
		go.renderer.material.mainTexture = LocationTexture;
		go.renderer.material.renderQueue = 4000;
		go.transform.localScale /= 27.0f;
		
		GameObject markerGO;
		markerGO = Instantiate(go) as GameObject;
		map.SetLocationMarker<LocationMarker>(markerGO);
		DestroyImmediate(go);
	}

	public void CreateAnnotationOnClick(double latitude,double longitude){
		go = Tile.CreateTileTemplate(Tile.AnchorPoint.BottomCenter).gameObject;
		go.renderer.material.mainTexture = MarkerTexture;
		go.renderer.material.renderQueue = 4001;
		go.transform.localScale = new Vector3(0.70588235294118f, 1.0f, 1.0f);
		go.transform.localScale /= 7.0f;
		go.AddComponent<CameraFacingBillboard>().Axis = Vector3.up;

		GameObject markerGO;
		markerGO = Instantiate(go) as GameObject;
		map.CreateMarker<Marker>("test marker - 9 rue Gentil, Lyon", new double[2] { longitude, latitude  }, markerGO);
		DestroyImmediate(go);

		print(("la coordenada es: "+ (map.CenterWGS84)[0].ToString()+" , "+(map.CenterWGS84)[1].ToString()));
	}
	
	#if DEBUG_PROFILE
	void LateUpdate()
	{
		Debug.Log("PROFILE:\n" + UnitySlippyMap.Profiler.Dump());
		UnitySlippyMap.Profiler.Reset();
	}
	#endif
}