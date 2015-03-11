using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWrapper
{
	public AbstractMap Map {
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
		if (Map != null)
		Map.CurrentZoom = currentZoom;
	}

	public void SetCurrentCamera (Camera currentCamera)
	{
		if (Map != null)
		Map.CurrentCamera = currentCamera;
	
	}

	public void setOriginCoordinates (BaseCoordinates coordinates)
	{
		Map.setOriginCoordinates (coordinates);
		//throw new NotImplementedException ();
	}

	public void EnableInputs ()
	{
		Map.InputsEnabled = true;
	}

	public void EnableUseLocation ()
	{
		Map.UseLocation = true;
	}

	public void addInputDelegateKeyboard ()
	{
		Map.addInputDelegateKeyboard ();
	}

	public void createVirtualEarthLayer (string key)
	{
		BaseVirtualEarthLayer layer = Map.createVirtualEarthLayer();
		layer.Key = key ;
		Map.SetActiveVirtualEarthLayer (layer);
		Layers.Add(layer);
	}

	public void createVirtualEarthLayer ()
	{
		Layers.Add(Map.createVirtualEarthLayer ());
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
		Map.AddMarker (new AppMarker ());
	}

	public void AddTemporalMarker ()
	{
		markers.Add (temporalMarker);
		temporalMarker = null;
	}

	public void SetMarkerInMap (AppMarker userGeneratedMarker)
	{
		markers.Add (new object ());
		Map.AddMarker (userGeneratedMarker);
	}


}
