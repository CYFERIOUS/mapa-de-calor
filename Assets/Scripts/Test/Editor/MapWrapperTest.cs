using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Test Category")]
	internal class MapWrapperTest {

		MapWrapper mapWrapper;
		AbstractMap map;

		[SetUp]
		public void Setup()
		{
			map = NSubstitute.Substitute.For<AbstractMap> ();
			mapWrapper = new MapWrapper ();
			mapWrapper.map = map;
		}

		[Test]
		[Category("Marker on map test")]
		public void TestPutMarkerOnMap(){
			AppMarker userGeneratedMarker = new AppMarker ();
			mapWrapper.SetMarkerInMap(userGeneratedMarker);
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Two Markers on map test")]
		public void TestPutTwoMarkersOnMap(){
			AppMarker userGeneratedMarker = new AppMarker ();
			mapWrapper.SetMarkerInMap (userGeneratedMarker);
			mapWrapper.SetMarkerInMap (userGeneratedMarker);
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

		[Test]
		[Category ("Map tests")]
		public void TestMapIsAddingAMarkerGeneratedByUser() {
			AppMarker userGeneratedMarker = new AppMarker ();
			mapWrapper.SetMarkerInMap (userGeneratedMarker);
			map.Received (1).AddMarker (userGeneratedMarker);
		}

		[Test, Ignore]
		[Category ( "Map Test")]
		public void TestMapHasPutTemporalMarker() {
			mapWrapper.SetTemporalMarker();
			//map.Received (1).AddMarker ();
		}
	}
}
