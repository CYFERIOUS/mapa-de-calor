using UnityEngine;
using System.Collections;

public class ConcreteMarker: AbstractMarker {

	public object Texture {
		get;
		set;
	}

	public BaseCoordinates Location {
		get;
		set;
	}
}
