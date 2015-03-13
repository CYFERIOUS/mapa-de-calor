using UnityEngine;
using System.Collections;
using NSubstitute;

public class MarkerGeneratorMock : MarkerGenerator  {
	protected override AbstractMarker CreateMarkerInstance ()
	{
		AbstractMarker marker = NSubstitute.Substitute.For<AbstractMarker> ();
		return marker;
	}
}
