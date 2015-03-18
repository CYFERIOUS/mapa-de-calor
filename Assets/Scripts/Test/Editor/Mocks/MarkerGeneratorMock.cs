using UnityEngine;
using System.Collections;
using NSubstitute;

public class MarkerGeneratorMock : MarkerGenerator  {
	protected override AbstractMarker CreateMarkerInstance (BaseCoordinates location)
	{
		AbstractMarker marker = NSubstitute.Substitute.For<AbstractMarker> ();
		return marker;
	}
	
	public override void DrawUserLocationMarker ()
	{
		AbstractMarker marker = NSubstitute.Substitute.For<AbstractMarker> ();
	}
}
