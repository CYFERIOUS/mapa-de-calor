using UnityEngine;
using System.Collections;

public class ConcreteMarkerGenerator : MarkerGenerator {

	protected override AbstractMarker CreateMarkerInstance ()
	{
		ConcreteMarker marker = new ConcreteMarker ();
		marker.Texture = DefaultTexture;
		return marker;
	}
		
}
