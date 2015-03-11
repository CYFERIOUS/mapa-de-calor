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

	bool UseLocation {
		get;
		set;
	}

	bool InputsEnabled {
		get;
		set;
	}

	List<AppMarker> GetMarkers ();
	void AddMarker(AppMarker marker);

	void setOriginCoordinates (BaseCoordinates coordinates);
	
	BaseVirtualEarthLayer createVirtualEarthLayer (string key);
	BaseVirtualEarthLayer createVirtualEarthLayer ();

	void SetActiveVirtualEarthLayer (BaseVirtualEarthLayer layer);

	void addInputDelegateKeyboard ();
}
