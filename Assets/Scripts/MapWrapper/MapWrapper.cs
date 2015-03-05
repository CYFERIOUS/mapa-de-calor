using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapWrapper
{
	public AbstractMap map {
		get;
		set;
	}

	private List<object> markers = new List<object> ();
	private object temporalMarker;

	public int MarkersCount {
		get {
			return markers.Count;
		} 
	}

	public bool HasTemporalMarker {
		get{
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
		map.AddMarker (new AppMarker());
	}

	public void AddTemporalMarker ()
	{
		markers.Add (temporalMarker);
		temporalMarker = null;
	}

	public void SetMarkerInMap (AppMarker userGeneratedMarker)
	{
		markers.Add (new object ());
		map.AddMarker (userGeneratedMarker);
	}
	
}
