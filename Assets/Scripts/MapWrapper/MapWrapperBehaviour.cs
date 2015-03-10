using UnityEngine;
using System.Collections;
using UnitySlippyMap;

public class MapWrapperBehaviour : MonoBehaviour {

	private AbstractMap	map;
	private MapWrapper mapWrapper;



	void Start ()
	{
		map = Map.Instance;
		mapWrapper = new MapWrapper ();

		mapWrapper.Map = map;
		mapWrapper.SetCurrentCamera (Camera.main);
		mapWrapper.SetCurrentZoom (15.0f);


		//SetupMapInstance ();
//		SetupVirtualEarthLayer ();
	}
	
	
	
	public void SetupVirtualEarthLayer ()
	{
		
		
		// create a VirtualEarth tile layer
		//VirtualEarthTileLayer virtualEarthLayer = map.CreateLayer<VirtualEarthTileLayer> ("VirtualEarth");
		//AbstractTileLayer virtualEarthLayer = mapWrapper.Map.CreateLayer("VirtualEarth");
		//virtualEarthLayer.Key = "Ag-ML2n_NjUqTCNOJyd9Yyr-GRfEWVmY_yboAe3A3aUL2JrE1d9er914Tfs9kgrp";
		//virtualEarthLayer.gameObject.SetActive (true);
		
		
		
	}
	
	public void SetupMapInstance ()
	{

//		mapWrapper.map.InputDelegate += UnitySlippyMap.Input.MapInput.BasicTouchAndKeyboard; 
//		mapWrapper.map.CurrentZoom = 15.0f;
//		mapWrapper.map.CenterWGS84 = new double[2] { -74.084046, 4.638194 };
//		mapWrapper.map.UseLocation = true;
//		mapWrapper.map.InputsEnabled = true;
//		mapWrapper.map.ShowGUIControls = false;
	}
}
