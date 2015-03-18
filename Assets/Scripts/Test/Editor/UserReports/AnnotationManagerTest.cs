using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("AnnotationManager Test")]
	internal class AnnotationManagerTest {

		protected AnnotationManager manager;
		protected ReportSaver saver;
		protected ReportLoader loader;
		protected Coordinates[] coords;

		protected MapWrapper mapWrapper;
		protected AbstractMap map;
		protected MarkerGenerator markerGenerator;
		protected BaseCoordinates temporalMarkerLocation;
		protected BaseCoordinates markerLocation;
		protected AbstractMarker marker;

		
		[SetUp]
		public void Setup(){
			SetUpAnnotationManager();
			SetUpSaver();
			fillData();
		}

		private void SetUpAnnotationManager() {
			SetUpMapWrapper();
			loader = new ReportLoader();
			loader.SetStorage(LoadDataAppConfig.GetStorage());
			manager = new AnnotationManager(loader, mapWrapper);
		}

		void SetUpMapWrapper () {
			SetUpSubstitutes ();
			markerGenerator = new MarkerGeneratorMock ();
			mapWrapper = new MapWrapper ();
			mapWrapper.MapImplementation = map;
			mapWrapper.MarkerGenerator = markerGenerator;
		}

		void SetUpSubstitutes () {
			map = NSubstitute.Substitute.For<AbstractMap> ();
			temporalMarkerLocation = NSubstitute.Substitute.For<BaseCoordinates> (1, 1);
			marker = NSubstitute.Substitute.For<AbstractMarker>();
		}

		void SetUpSaver () {
			saver = new ReportSaver();
			saver.SetStorage(LoadDataAppConfig.GetStorage());
		}

		private void fillData() {
			SetUpCoords();
			for(int i = 0;i < coords.Length; ++i) {
				FormData data = new FormData();
				data.annotation = new Vector2((float)coords[i].Latitude, (float)coords[i].Longitude);
				saver.SetKey(i);
				saver.Save(data);
			}
		}

		private void SetUpCoords() {
			coords = new Coordinates[] {
				new Coordinates(4.63712,-74.08491),
				new Coordinates(4.64153,-74.08588),
				new Coordinates(4.64191,-74.08135),
				new Coordinates(4.63839,-74.08124)
			};
		}

		[Test]
		[Category("Annotations are loaded")]
		public void AnnotationsAreLoaded() {
			manager.loadAnnotations();
			Assert.AreEqual(manager.mapWrapper.MarkersCount, manager.AnnotationsCount());
		}

	}
}

public class LoadDataAppConfig{
	
	static public IDataStorage GetStorage(){
		return new PlayerPrefStorage();
	}
}
