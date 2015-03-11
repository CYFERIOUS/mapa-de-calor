using UnityEngine;
using System.Collections;
using UnitySlippyMap;

public class MapWrapperBehaviour : OpenMapWrapper{

	private MapWrapper mapWrapper;
	//private Map map;

	void Start ()
	{
		map = Map.Instance;
		mapWrapper = new MapWrapper ();
		mapWrapper.Map = map;
		SetupMapInstance ();	
		SetUpInputReader ();
	}
	

	public void SetupMapInstance ()
	{
		mapWrapper.SetCurrentCamera (Camera.main);
		mapWrapper.SetCurrentZoom (15.0f);
		mapWrapper.createVirtualEarthLayer ("Ag-ML2n_NjUqTCNOJyd9Yyr-GRfEWVmY_yboAe3A3aUL2JrE1d9er914Tfs9kgrp");
		mapWrapper.setOriginCoordinates (new Coordinates(-74.084046, 4.638194));
		mapWrapper.EnableUseLocation ();
		mapWrapper.addInputDelegateKeyboard ();
		mapWrapper.EnableInputs ();
		//map.ShowGUIControls = false;
	}
}
