using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MarkerGenerator
{
	public object DefaultTexture {
		get;
		set;
	}

	public AbstractMarker GenerateMarker(BaseCoordinates location)
	{
		AbstractMarker markerInstance = CreateMarkerInstance();
		markerInstance.Location = location;
		return markerInstance;
	}

	protected abstract AbstractMarker CreateMarkerInstance();
}

