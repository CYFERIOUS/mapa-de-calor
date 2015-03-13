using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest
{
	[TestFixture]
	[Category("Test Category")]
	internal class MapWrapperTest
	{

		MapWrapper mapWrapper;
		AbstractMap Map;

		[SetUp]
		public void Setup ()
		{
			Map = NSubstitute.Substitute.For<AbstractMap> ();
			mapWrapper = new MapWrapper ();
			mapWrapper.MapImplementation = Map;
		}

		[Test]
		[Category("Marker on map test")]
		public void TestPutMarkerOnMap ()
		{	
			BaseCoordinates markerLocation = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			mapWrapper.SetMarkerInMap (markerLocation);
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Two Markers on map test")]
		public void TestPutTwoMarkersOnMap ()
		{
			BaseCoordinates markerLocation = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			mapWrapper.SetMarkerInMap (markerLocation);
			mapWrapper.SetMarkerInMap (markerLocation);
			Assert.AreEqual (2, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Set Temporal Marker test")]
		public void TestSettingTemporalMarkerMakesMapHasATemporalMarker ()
		{ 
			mapWrapper.SetTemporalMarker ();
			Assert.IsTrue (mapWrapper.HasTemporalMarker);
		}

		[Test]
		[Category("Temporal Marker test")]
		public void TestAddingTemporalMarkerMakesMapHasNoTemporalMarker ()
		{
			mapWrapper.SetTemporalMarker ();
			mapWrapper.AddTemporalMarker ();
			Assert.IsFalse (mapWrapper.HasTemporalMarker);
		}

		[Test]
		[Category("Temporal Marker test")]
		public void TestAddingTemporalMarkerPutsMarker ()
		{
			mapWrapper.SetTemporalMarker ();
			mapWrapper.AddTemporalMarker ();
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}

		[Test, Ignore]
		[Category ("Map add marker tests")]
		public void TestMapIsAddingAMarkerGeneratedByUser ()
		{
			AbstractMarker userGeneratedMarker = new AbstractMarker ();
			BaseCoordinates markerLocation = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			mapWrapper.SetMarkerInMap (markerLocation);
			Map.Received (1).AddMarker (userGeneratedMarker);
		}

		[Test]
		[Category ("Map setup camera tests")]
		public void TestMapSetupsCurrentCamera ()
		{
			Camera currentCamera = new Camera ();

			mapWrapper.SetCurrentCamera (currentCamera);
			Assert.IsNotNull (mapWrapper.MapImplementation.CurrentCamera);
		}

		[Test]
		[Category("Map setup camera tests")]
		public void TestNotSetupCameraIfMapIsNull ()
		{
			Camera currentCamera = new Camera ();
			mapWrapper.MapImplementation = null;

			Assert.DoesNotThrow (() => {
				mapWrapper.SetCurrentCamera (currentCamera);
			});
		}

		[Test]
		[Category("Map setup zoom tests")]
		public void TestMapSetupsCurrentZoom ()
		{
			float currentZoom = 10.0f;
			mapWrapper.SetCurrentZoom (currentZoom);
			Assert.AreEqual (currentZoom, mapWrapper.MapImplementation.CurrentZoom); 
		}

		[Test]
		[Category("Map setup zoom tests")]
		public void TestNoSetupCurrentZoomIfMapIsNull ()
		{
			float currentZoom = 10.0f;
			mapWrapper.MapImplementation = null;
			mapWrapper.SetCurrentZoom (currentZoom);
			Assert.DoesNotThrow (() => {
				mapWrapper.SetCurrentZoom (currentZoom);
			});
		}

		[Test]
		[Category("Map setup layer")]
		public void TestAddANewLayer(){
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			mapWrapper.AddLayer (layer);
			Assert.Contains (layer, mapWrapper.Layers);
		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestMapCreatesVirtualEarthLayer(){
			mapWrapper.createVirtualEarthLayer ();
			Map.Received (1).createVirtualEarthLayer ();

		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestAddVirtualEarthLayer(){
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			Map.createVirtualEarthLayer().Returns(layer);
			mapWrapper.createVirtualEarthLayer();
			Assert.Contains(layer, mapWrapper.Layers);

		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestSetVirtualEarthLayerKey(){
			string key = "Dummykey";
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			Map.createVirtualEarthLayer().Returns(layer);
			mapWrapper.createVirtualEarthLayer(key);
			Assert.AreEqual (key, mapWrapper.Layers[0].Key); // Es correcto hacer esto?

		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestVirtualEarthLayerGameObjectIsSetActive(){
			string key = "Dummykey";
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			Map.createVirtualEarthLayer().Returns(layer);
			mapWrapper.createVirtualEarthLayer(key);
			Map.Received(1).SetActiveVirtualEarthLayer (mapWrapper.Layers[0]); // Es correcto hacer esto?
		}

		[Test]
		[Category("Map setup start coordinates")]
		public void TestInitialCoordinatesAreSet(){
			BaseCoordinates coordinates = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			mapWrapper.setOriginCoordinates (coordinates);
			Map.Received (1).setOriginCoordinates (coordinates);
		}

		[Test]
		[Category("Map setup enable use location")]
		public void TestEnableUseLocation(){
			mapWrapper.EnableUseLocation ();
			Assert.IsTrue (Map.UseLocation);
		}

		[Test]
		[Category("Map add input delegate")]
		public void TestAddInputDelegateKeyboard(){
			mapWrapper.addInputDelegateKeyboard();
			Map.Received (1).addInputDelegateKeyboard ();
		}

		[Test]
		[Category("Enable inputs")]
		public void TestEnableInputs(){
			mapWrapper.EnableInputs ();
			Assert.IsTrue (Map.InputsEnabled);
		}

		[Test]
		[Category("Set user location")]
		public void TestSetUserLocationIsSet(){
			mapWrapper.SetUserLocation ();
			Map.Received (1).SetUserLocation ();
		}

		[Test]
		[Category("Test Marker has coordinates")]
		public void TestMarkerHasCoordinates(){
			BaseCoordinates markerLocation = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			AbstractMarker argumentUsed = null;
			Map.AddMarker (Arg.Do<AbstractMarker> (x => argumentUsed = x));//  [0].Location, markerLocation);
			mapWrapper.SetMarkerInMap (markerLocation);
			Assert.AreSame (markerLocation, argumentUsed.Location);
		}

	}
}