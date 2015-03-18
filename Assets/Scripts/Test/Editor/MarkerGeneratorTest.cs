using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	[Category("Test Category")]
	internal class MarkerGeneratorTest
	{
		MarkerGenerator MarkerGeneratorMock = new MarkerGeneratorMock();

		[Test]
		[Category("Create Marker With default texture")]
		public void TestCreateMarkerWithDefaultTexture()
		{	
			BaseCoordinates location = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			AbstractMarker marker = MarkerGeneratorMock.GenerateMarker (location);
			Assert.AreEqual (MarkerGeneratorMock.DefaultTexture, marker.Texture);
		}

	}
}