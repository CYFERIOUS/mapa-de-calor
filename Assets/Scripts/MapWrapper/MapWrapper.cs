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

	public List<object> LayerNames = new List<object> (); 

	public void SetupLayer (string layerName)
	{
		LayerNames.Add (layerName);
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

	private List<object> markers = new List<object> ();
	private object temporalMarker;

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
