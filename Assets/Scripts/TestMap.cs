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
	
	private void
	Start ()
	{

	}

	void Update ()
	{
//		if (destinationAngle != 0.0f) {
//			Vector3 cameraLeft = Quaternion.AngleAxis (-90.0f, Camera.main.transform.up) * Camera.main.transform.forward;
//			if ((Time.time - animationStartTime) < animationDuration) {
//				float angle = Mathf.LerpAngle (0.0f, destinationAngle, (Time.time - animationStartTime) / animationDuration);
//				Camera.main.transform.RotateAround (Vector3.zero, cameraLeft, angle - currentAngle);
//				currentAngle = angle;
//			} else {
//				Camera.main.transform.RotateAround (Vector3.zero, cameraLeft, destinationAngle - currentAngle);
//				destinationAngle = 0.0f;
//				currentAngle = 0.0f;
//				map.IsDirty = true;
//			}
//			
//			map.HasMoved = true;
//		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
			
	}

	void OnApplicationQuit ()
	{
		map = null;
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

	public void CreateAnnotationOnClick (double latitude, double longitude)
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