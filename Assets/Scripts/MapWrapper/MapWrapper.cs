using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWrapper
{
	public AbstractMap MapImplementation {
		get;
		set;
	}

	public int MarkersCount {
	
		get {
			return markers.Count;
		} 
	}
	
	public List<BaseVirtualEarthLayer> Layers = new List<BaseVirtualEarthLayer> (); 
	private List<object> markers = new List<object> ();
	private object temporalMarker;

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
		//throw new NotImplementedException ();
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

	public bool HasTemporalMarker {
		get {
			return temporalMarker != null;
		}
	}

	public Dictionary<string, double> GetCoordinatesOfCursor ()
	{
		return new Dictionary<string, double> ();
	}

	public void SetTemporalMarker ()
	{
		temporalMarker = new object ();
		MapImplementation.AddMarker (new AbstractMarker ());
	}

	public void AddTemporalMarker ()
	{
		markers.Add (temporalMarker);
		temporalMarker = null;
	}

	public void SetMarkerInMap (AbstractMarker userGeneratedMarker)
	{
		markers.Add (new object ());
		MapImplementation.AddMarker (userGeneratedMarker);
	}


}
