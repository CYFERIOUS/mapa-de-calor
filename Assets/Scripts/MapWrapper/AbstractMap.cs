using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface AbstractMap {
	float CurrentZoom {
		get;
		set;
	}

	Camera CurrentCamera {
		get;
		set;
	}


	List<AppMarker> GetMarkers ();
	void AddMarker(AppMarker marker);
	
	BaseVirtualEarthLayer createVirtualEarthLayer (string key);
	BaseVirtualEarthLayer createVirtualEarthLayer ();

	void SetActiveVirtualEarthLayer (BaseVirtualEarthLayer layer);
}
