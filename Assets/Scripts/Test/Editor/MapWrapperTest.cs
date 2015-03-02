using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest {
	[TestFixture]
	[Category("Test Category")]
	internal class MapWrapperTest {

		MapWrapper map;

		[SetUp]
		public void Setup()
		{
			map = new MapWrapperMock ();
		}


		[Test]
		[Category("Marker on map test")]
		public void TestPutMarkerOnMap(){
			map.SetSingleMarkerOnMap();
			Assert.AreEqual (1, map.Markers.Count);
		}
	}
}
