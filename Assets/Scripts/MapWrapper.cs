using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

interface MapWrapper{
	Dictionary<string, double> GetCursorCoordinates();
	void SetMarkerInMap();
	void SetCoordinatesOnInputField(double latitude, double longitude);
	void SetToFalseIsMarkerSet();
	void DetectDoubleTap();
}