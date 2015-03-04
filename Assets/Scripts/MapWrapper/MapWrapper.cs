using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

interface MapWrapper{
	Dictionary<string, double> GetCoordinatesOfCursor();
	void SetSingleMarkerOnMap();
	void SetMarkerInMap();
	void SetCoordinatesOnInputField(double latitude, double longitude);
	void DetectDoubleTap();
}