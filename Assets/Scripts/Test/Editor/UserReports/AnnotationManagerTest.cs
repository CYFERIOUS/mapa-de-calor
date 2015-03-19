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
		[Category("All Annotations are loaded")]
		public void TestAllAnnotationsAreLoaded() {
			manager.loadAnnotations();
			Assert.AreEqual(manager.mapWrapper.MarkersCount, manager.AnnotationsCount());
		}

		[Test]
		[Category("Reports are loaded")]
		public void TestReportsAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			Assert.AreEqual(data.Length, dataLoaded.Count);
		}

		[Test]
		[Category("Keys are loaded")]
		public void TestKeysAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			for(int key = 0; key<data.Length;key++)
				Assert.AreEqual(data[key].key, ((FormData)dataLoaded[key]).key);
		}

		[Test]
		[Category("Names are loaded")]
		public void TestNamesAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			for(int key = 0;key<data.Length;key++)
				Assert.AreEqual(data[key].name, ((FormData)dataLoaded[key]).name);
		}

		[Test]
		[Category("Annotations are loaded")]
		public void TestAnnotationsAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			for(int key = 0; key<data.Length;key++){
				Assert.AreEqual(data[key].annotation.x, ((FormData)dataLoaded[key]).annotation.x);
				Assert.AreEqual(data[key].annotation.y, ((FormData)dataLoaded[key]).annotation.y);
			}
		}

		[Test]
		[Category("Comments are loaded")]
		public void TestCommentsAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			for(int key = 0; key<data.Length;key++){
				Assert.AreEqual(data[key].comments, ((FormData)dataLoaded[key]).comments);
			}
		}

		[Test]
		[Category("Stuff are loaded")]
		public void TestStuffAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			for(int key = 0; key<data.Length;key++){
				Assert.AreEqual(data[key].stuff, ((FormData)dataLoaded[key]).stuff);
			}
		}

		[Test]
		[Category("Ocurrence are loaded")]
		public void TestOcurrenceAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			for(int key = 0; key<data.Length;key++){
				Assert.AreEqual(data[key].ocurrence, ((FormData)dataLoaded[key]).ocurrence);
			}
		}

		[Test]
		[Category("TimeStamp are loaded")]
		public void TestTimeStampAreLoaded() {
			ArrayList dataLoaded = manager.getReports();
			for(int key = 0; key<data.Length;key++){
				Assert.AreEqual(data[key].timestamp, ((FormData)dataLoaded[key]).timestamp);
			}
		}

	}
}
