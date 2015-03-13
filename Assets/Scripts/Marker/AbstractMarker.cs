using UnityEngine;
using System.Collections;

public interface AbstractMarker {
	object Texture {
		get;
		set;
	}

	 BaseCoordinates Location {
		get;
		set;
	}
}
