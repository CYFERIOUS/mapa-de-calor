using UnityEngine;
using System.Collections;
using UnitySlippyMap;

public class MapWrapperBehaviour : OpenMapWrapper {

	private MapWrapper mapWrapper;

	void Start ()
	{
		map = Map.Instance;
		mapWrapper = new MapWrapper ();

		mapWrapper.Map = map;
		mapWrapper.SetCurrentCamera (Camera.main);
		mapWrapper.SetCurrentZoom (15.0f);
		mapWrapper.createVirtualEarthLayer ("Ag-ML2n_NjUqTCNOJyd9Yyr-GRfEWVmY_yboAe3A3aUL2JrE1d9er914Tfs9kgrp");


		SetupMapInstance ();


		SetUpInputReader ();
	}
	

	public void SetupMapInstance ()
	{
		map.InputDelegate += UnitySlippyMap.Input.MapInput.BasicTouchAndKeyboard; 
		map.CenterWGS84 = new double[2] { -74.084046, 4.638194 };
		map.UseLocation = true;
		map.InputsEnabled = true;
		map.ShowGUIControls = false;
	}
}
