using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySlippyMap;


public class MapMonoBehaviour : MonoBehaviour {
	public MapWrapper mapWrapper;	

	void start(){
		mapWrapper = new MapWrapper ();
		mapWrapper.map = Map.Instance;
	}
}


public class MapWrapper
{
	public object map {
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
	}

	public void AddTemporalMarker ()
	{
		markers.Add (temporalMarker);
		temporalMarker = null;
	}

	public void SetMarkerInMap ()
	{
		markers.Add (new object ());
	}
}
