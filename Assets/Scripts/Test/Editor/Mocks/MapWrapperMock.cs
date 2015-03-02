using System;
using System.Collections;
using System.Collections.Generic;

public class MapWrapperMock : MapWrapper
{
	public Dictionary<string, double> GetCoordinatesOfCursor ()
	{
		return new Dictionary<string, double> ();
	}

	public void SetSingleMarkerOnMap ()
	{
		markers.Add (new object ());
	}

	public void SetMarkerInMap ()
	{
	}

	public void SetCoordinatesOnInputField (double latitude, double longitude)
	{
	}

	public void DetectDoubleTap ()
	{
	}

	private List<object> markers = new List<object> ();
	public List<object> Markers {get {return markers;} }

}
