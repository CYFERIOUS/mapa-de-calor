﻿using System;
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
			mapWrapper.Map = Map;
		}

		[Test]
		[Category("Marker on map test")]
		public void TestPutMarkerOnMap ()
		{
			AppMarker userGeneratedMarker = new AppMarker ();
			mapWrapper.SetMarkerInMap (userGeneratedMarker);
			Assert.AreEqual (1, mapWrapper.MarkersCount);
		}

		[Test]
		[Category("Two Markers on map test")]
		public void TestPutTwoMarkersOnMap ()
		{
			AppMarker userGeneratedMarker = new AppMarker ();
			mapWrapper.SetMarkerInMap (userGeneratedMarker);
			mapWrapper.SetMarkerInMap (userGeneratedMarker);
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

		[Test]
		[Category ("Map add marker tests")]
		public void TestMapIsAddingAMarkerGeneratedByUser ()
		{
			AppMarker userGeneratedMarker = new AppMarker ();
			mapWrapper.SetMarkerInMap (userGeneratedMarker);
			Map.Received (1).AddMarker (userGeneratedMarker);
		}

		[Test]
		[Category ("Map setup camera tests")]
		public void TestMapSetupsCurrentCamera ()
		{
			Camera currentCamera = new Camera ();

			mapWrapper.SetCurrentCamera (currentCamera);
			Assert.IsNotNull (mapWrapper.Map.CurrentCamera);
		}

		[Test]
		[Category("Map setup camera tests")]
		public void TestNotSetupCameraIfMapIsNull ()
		{
			Camera currentCamera = new Camera ();
			mapWrapper.Map = null;

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
			Assert.AreEqual (currentZoom, mapWrapper.Map.CurrentZoom); 
		}

		[Test]
		[Category("Map setup zoom tests")]
		public void TestNoSetupCurrentZoomIfMapIsNull ()
		{
			float currentZoom = 10.0f;
			mapWrapper.Map = null;
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
			Map.createVirtualEarthLayer(key).Returns(layer);
			mapWrapper.createVirtualEarthLayer(key);
			Assert.AreEqual (key, mapWrapper.Layers[0].Key); // Es correcto hacer esto?

		}

		[Test]
		[Category("Map setup VirtualEarth layer")]
		public void TestVirtualEarthLayerGameObjectIsSetActive(){
			string key = "Dummykey";
			BaseVirtualEarthLayer layer = NSubstitute.Substitute.For<BaseVirtualEarthLayer> ();
			Map.createVirtualEarthLayer(key).Returns(layer);
			mapWrapper.createVirtualEarthLayer(key);
			Map.Received(1).SetActiveVirtualEarthLayer (mapWrapper.Layers[0]); // Es correcto hacer esto?
		}

		[Test]
		[Category("Map setup start coordinates")]
		public void TestInitialCoordinatesAreSet(){
			double latitude = 1111;
			double longitude = 1111;
			BaseCoordinates coordinates = NSubstitute.Substitute.For<BaseCoordinates> (latitude, longitude);
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
	}
}