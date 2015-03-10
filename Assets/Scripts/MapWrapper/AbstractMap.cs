﻿using UnityEngine;
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

	System.Collections.ICollection Layers {
		get;
		set;
	}

	AbstractTileLayer CreateLayer (string virtualEarth);
	List<AppMarker> GetMarkers ();
	void AddMarker(AppMarker marker);
}