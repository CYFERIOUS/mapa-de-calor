using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWrapper
{
	private MarkerGenerator markerGenerator;
	public List<BaseVirtualEarthLayer> Layers = new List<BaseVirtualEarthLayer> ();
	private List<AbstractMarker> markers = new List<AbstractMarker> ();
	private AbstractMarker temporalAbstractMarker;

	public AbstractMap MapImplementation {
		get;
		set;
	}
	
	public MarkerGenerator MarkerGenerator
	{
		set {
			markerGenerator = value;
		}
	}

	public int MarkersCount {
	
		get {
			return markers.Count;
		} 
	}

	public bool HasTemporalMarker {
		get {
			return temporalAbstractMarker != null;
		}
	}

	public void SetUserLocation ()
	{
		markerGenerator.DrawUserLocationMarker ();
	}

	public void AddLayer (BaseVirtualEarthLayer layer)
	{
		Layers.Add (layer);
	}

	public void SetCurrentZoom (float currentZoom)
	{
		if (MapImplementation != null)
		MapImplementation.CurrentZoom = currentZoom;
	}

	public void SetCurrentCamera (Camera currentCamera)
	{
		if (MapImplementation != null)
		MapImplementation.CurrentCamera = currentCamera;
	
	}

	public void setOriginCoordinates (BaseCoordinates coordinates)
	{
		MapImplementation.setOriginCoordinates (coordinates);
	}

	public void EnableInputs ()
	{
		MapImplementation.InputsEnabled = true;
	}

	public void EnableUseLocation ()
	{
		MapImplementation.UseLocation = true;
	}

	public void addInputDelegateKeyboard ()
	{
		MapImplementation.addInputDelegateKeyboard ();
	}

	public void createVirtualEarthLayer (string key)
	{
		BaseVirtualEarthLayer layer = MapImplementation.createVirtualEarthLayer();
		layer.Key = key ;
		MapImplementation.SetActiveVirtualEarthLayer (layer);
		Layers.Add(layer);
	}

	public void createVirtualEarthLayer ()
	{
		Layers.Add(MapImplementation.createVirtualEarthLayer ());
	}

	public void SetTemporalMarker(BaseCoordinates coordinates){
		temporalAbstractMarker = markerGenerator.GenerateMarker (coordinates);
		MapImplementation.AddMarker (temporalAbstractMarker);
	}

	public void AddTemporalMarker ()
	{
		markers.Add (temporalAbstractMarker);
		temporalAbstractMarker = null;
	}

	public void SetMarkerInMap (BaseCoordinates coordinates)
	{
		AbstractMarker marker = markerGenerator.GenerateMarker(coordinates);
		marker.Location = coordinates;
		markers.Add (marker);
		MapImplementation.AddMarker (marker);
	}
}
