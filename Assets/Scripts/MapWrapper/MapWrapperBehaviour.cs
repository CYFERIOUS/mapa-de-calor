using UnityEngine;
using System.Collections;
using UnitySlippyMap;

public class MapWrapperBehaviour: OpenMapWrapper{

	private MapWrapper mapWrapper;
	private AbstractMap mapImplementation;

	void Start ()
	{	
		map = Map.Instance;
		mapImplementation = new MapImplementation ();
		mapWrapper = new MapWrapper ();
		mapWrapper.MapImplementation = mapImplementation;
		SetupMapInstance ();	

		DrawGPSUserLocation ();
		SetUpInputReader ();
		PrivateTriggerMovementManager = map.CenterWGS84 [0];
	}

	void Update ()
	{
		if (isOnMainWindow == true) {
			inputReader.Update ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		
		if (PrivateTriggerMovementManager != map.CenterWGS84 [0] && ReportTrigger.activeInHierarchy == true) {
			ReportTrigger.SetActive (false);
			RemoveLastPutMarker ();
		}
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

	}
}
