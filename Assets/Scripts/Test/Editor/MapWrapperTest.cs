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
		AbstractMap map;
		MarkerGenerator markerGenerator;
		BaseCoordinates temporalMarkerLocation;
		BaseCoordinates markerLocation;
		AbstractMarker marker;

		[SetUp]
		public void Setup ()
		{	
			SetUpSubstitutes ();
			markerGenerator = new MarkerGeneratorMock ();
			mapWrapper = new MapWrapper ();
			mapWrapper.MapImplementation = map;
			mapWrapper.MarkerGenerator = markerGenerator;
		}

		private void SetUpSubstitutes()
		{
			map = NSubstitute.Substitute.For<AbstractMap> ();
			temporalMarkerLocation = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			marker = NSubstitute.Substitute.For<AbstractMarker>();
		}

		[Test]
		[Category("Marker on map test")]
		public void TestPutMarkerOnMap ()
		{	
			mapWrapper.SetMarkerInMap (markerLocation);
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Two Markers on map test")]
		public void TestPutTwoMarkersOnMap ()
		{
			mapWrapper.SetMarkerInMap (markerLocation);
			mapWrapper.SetMarkerInMap (markerLocation);
			Assert.AreEqual (2, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Set Temporal Marker test")]
		public void TestSettingTemporalMarkerMakesMapHasATemporalMarker ()
		{ 
			mapWrapper.SetTemporalMarker (temporalMarkerLocation);
			Assert.IsTrue (mapWrapper.HasTemporalMarker);
		}

		[Test]
		[Category("Test temporal marker is instance of abstract marker")]
		public void TestTemporalMarkerIsInstanceOfAbstractMarker(){
			mapWrapper.SetTemporalMarker (temporalMarkerLocation);
			map.Received (1).AddMarker (Arg.Any<AbstractMarker>());
		}

		[Test]
		[Category("Test temporal marker has coordinates")]
		public void TestTemporalMarkerHasLocationSetByUser(){
			AbstractMarker argumentUsed = null;
			map.AddMarker (Arg.Do<AbstractMarker> (x => argumentUsed = x));
			mapWrapper.SetTemporalMarker (temporalMarkerLocation);
			Assert.AreSame (temporalMarkerLocation, argumentUsed.Location);
		}

		[Test]
		[Category("Temporal Marker test")]
		public void TestAddingTemporalMarkerMakesMapHasNoTemporalMarker ()
		{
			mapWrapper.SetTemporalMarker (temporalMarkerLocation);
			mapWrapper.AddTemporalMarker ();
			Assert.IsFalse (mapWrapper.HasTemporalMarker);
		}

		[Test]
		[Category("Temporal Marker test")]
		public void TestAddingTemporalMarkerPutsMarker ()
		{
			mapWrapper.SetTemporalMarker (temporalMarkerLocation);
			mapWrapper.AddTemporalMarker ();
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Test Marker has coordinates")]
		public void TestMarkerHasCoordinates(){
			AbstractMarker argumentUsed = null;
			map.AddMarker (Arg.Do<AbstractMarker> (x => argumentUsed = x));
			mapWrapper.SetMarkerInMap (markerLocation);
			Assert.AreSame (markerLocation, argumentUsed.Location);
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
			map.Received (1).createVirtualEarthLayer ();

		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestAddVirtualEarthLayer(){
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			map.createVirtualEarthLayer().Returns(layer);
			mapWrapper.createVirtualEarthLayer();
			Assert.Contains(layer, mapWrapper.Layers);

		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestSetVirtualEarthLayerKey(){
			string key = "Dummykey";
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			map.createVirtualEarthLayer().Returns(layer);
			mapWrapper.createVirtualEarthLayer(key);
			Assert.AreEqual (key, mapWrapper.Layers[0].Key);

		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestVirtualEarthLayerGameObjectIsSetActive(){
			string key = "Dummykey";
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			map.createVirtualEarthLayer().Returns(layer);
			mapWrapper.createVirtualEarthLayer(key);
			map.Received(1).SetActiveVirtualEarthLayer (mapWrapper.Layers[0]);
		}

		[Test]
		[Category("Map setup start coordinates")]
		public void TestInitialCoordinatesAreSet(){
			BaseCoordinates coordinates = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			mapWrapper.setOriginCoordinates (coordinates);
			map.Received (1).setOriginCoordinates (coordinates);
		}

		[Test]
		[Category("Map setup enable use location")]
		public void TestEnableUseLocation(){
			mapWrapper.EnableUseLocation ();
			Assert.IsTrue (map.UseLocation);
		}

		[Test]
		[Category("Map add input delegate")]
		public void TestAddInputDelegateKeyboard(){
			mapWrapper.addInputDelegateKeyboard();
			map.Received (1).addInputDelegateKeyboard ();
		}

		[Test]
		[Category("Enable inputs")]
		public void TestEnableInputs(){
			mapWrapper.EnableInputs ();
			Assert.IsTrue (map.InputsEnabled);
		}

		[Test]
		[Category("Set user location")]
		public void TestSetUserLocationIsSet(){
			mapWrapper.SetUserLocation ();
			map.Received (1).SetUserLocation ();
		}

	}
}