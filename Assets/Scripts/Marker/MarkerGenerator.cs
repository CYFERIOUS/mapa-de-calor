using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MarkerGenerator
{
	public Texture UserLocationTexture {
		get;
		set;
	}

	public Texture DefaultTexture {
		get;
		set;
	}

	public AbstractMarker GenerateMarker(BaseCoordinates location)
	{
		AbstractMarker markerInstance = CreateMarkerInstance(location);
		markerInstance.Location = location;
		return markerInstance;
	}
	
	public abstract void DrawUserLocationMarker();
	protected abstract AbstractMarker CreateMarkerInstance(BaseCoordinates location);

}

