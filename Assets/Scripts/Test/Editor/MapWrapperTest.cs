using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest {
	[TestFixture]
	[Category("Test Category")]
	internal class MapWrapperTest {

		MapWrapper mapWrapper;

		[SetUp]
		public void Setup()
		{
			mapWrapper = new MapWrapper ();
			mapWrapper.map = new MapMock();
		}

		[Test]
		[Category("Marker on map test")]
		public void TestPutMarkerOnMap(){
			mapWrapper.SetMarkerInMap();
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Two Markers on map test")]
		public void TestPutTwoMarkersOnMap(){
			mapWrapper.SetMarkerInMap ();
			mapWrapper.SetMarkerInMap ();
			Assert.AreEqual (2,mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Set Temporal Marker test")]
		public void TestSettingTemporalMarkerMakesMapHasATemporalMarker(){
			mapWrapper.SetTemporalMarker();
			Assert.IsTrue(mapWrapper.HasTemporalMarker);
		}

		[Test]
		[Category("Temporal Marker test")]
		public void TestAddingTemporalMarkerMakesMapHasNoTemporalMarker(){
			mapWrapper.SetTemporalMarker();
			mapWrapper.AddTemporalMarker();
			Assert.IsFalse(mapWrapper.HasTemporalMarker);
		}

		[Test]
		[Category("Temporal Marker test")]
		public void TestAddingTemporalMarkerPutsMarker(){
			mapWrapper.SetTemporalMarker();
			mapWrapper.AddTemporalMarker();
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}
		/*[Test]
		[Category("*/
	

	}
}
