using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	[Category("Test Category")]
	internal class ConcreteMarkerGeneratorTest
	{
		MarkerGenerator concreteMarkerGenerator = new ConcreteMarkerGenerator();

		[Test]
		[Category("Create Marker With default texture")]
		public void TestCreateMarkerWithDefaultTexture()
		{	
			BaseCoordinates location = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			AbstractMarker marker = concreteMarkerGenerator.GenerateMarker (location);
			Assert.AreEqual (concreteMarkerGenerator.DefaultTexture, marker.Texture);
		}
	}
}