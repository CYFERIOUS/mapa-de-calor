using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface AbstractMap {
	List<AppMarker> GetMarkers ();
	void AddMarker(AppMarker marker);
}
