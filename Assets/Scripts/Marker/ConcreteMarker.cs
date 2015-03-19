using UnityEngine;
using System.Collections;
using UnitySlippyMap;

public class ConcreteMarker: Marker, AbstractMarker {

	public Texture Texture {
		get;
		set;
	}

	public BaseCoordinates Location {
		get;
		set;
	}

	public int Id {
		get;
		set;
	}
}
