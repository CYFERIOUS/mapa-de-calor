using UnityEngine;
using System.Collections;

public interface AbstractMarker {
	Texture Texture {
		get;
		set;
	}

	 BaseCoordinates Location {
		get;
		set;
	}

	int Id {
		get;
		set;
	}
}
