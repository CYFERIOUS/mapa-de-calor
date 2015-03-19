using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using System.Collections;

namespace UnityTest {
	[TestFixture]
	[Category("AnnotationManager Test")]
	internal class AnnotationManagerTest : DataIOTestBase {

		protected AnnotationManager manager;

		protected MapWrapper mapWrapper;
		protected AbstractMap map;
		protected MarkerGenerator markerGenerator;
		protected BaseCoordinates temporalMarkerLocation;
		protected BaseCoordinates markerLocation;
		protected AbstractMarker marker;

		
		[SetUp]
		public void Setup(){
			SetUpAnnotationManager();
			fillData();
		}

		private void SetUpAnnotationManager() {
			SetUpMapWrapper();
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

		private void fillData() {
			for(int key = 0;key < keyTotals; ++key) {
				saver.SetKey(key);
				saver.Save(data[key]);
			}
		}

		[Test]
		[Category("Annotations are loaded")]
		public void TestAnnotationsAreLoaded() {
			manager.loadAnnotations();
			Assert.AreEqual(manager.mapWrapper.MarkersCount, manager.AnnotationsCount());
		}

		[Test]
		[Category("Reports are loaded")]
		public void TestReportsAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			Assert.AreEqual(data.Length, dataLoaded.Count);
		}

	}
}

public class LoadDataAppConfig{
	
	static public IDataStorage GetStorage(){
		return new PlayerPrefStorage();
	}
}
