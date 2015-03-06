using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest {
	[TestFixture]
	[Category("Test Category")]
	internal class DataStorageTests {

		IDataStorage storage;

		string name;
		string comments;
		Vector2 annotation;
		int timestamp;
		string stuff;
		int ocurrence;

		[SetUp]
		public void Setup() {
			storage = new PlayerPrefStorage();
			name = "name";
			comments = "comments";
			annotation = new Vector2(1,2);
			timestamp = 338498400;
			stuff = "article";
			ocurrence = (int)Ocurrence.Assault;
		}

		[Test]
		[Category("Name is saved")]
		public void TestNameIsSaved() {
			storage.SetName (name);
			storage.save ();
			Assert.AreEqual (name, storage.GetName());
		}

		[Test]
		[Category("comments are saved")]
		public void TestCommentsAreSaved() {
			storage.SetComments (comments);
			storage.save ();
			Assert.AreEqual (comments, storage.GetComments());
		}

		[Test]
		[Category("Annotation is saved")]
		public void TestAnnotationIsSaved() {
			storage.SetAnnotation (annotation);
			storage.save ();
			Assert.AreEqual (annotation.x, storage.GetAnnotation().x);
			Assert.AreEqual (annotation.y, storage.GetAnnotation().y);
		}

		[Test]
		[Category("Timestamp is saved")]
		public void TestTimestampIsSaved() {
			storage.SetTimestamp (timestamp);
			storage.save ();
			Assert.AreEqual (timestamp, storage.GetTimestamp());
		}

		[Test]
		[Category("Stuff is saved")]
		public void TestStuffIsSaved() {
			storage.SetStuff (stuff);
			storage.save ();
			Assert.AreEqual (stuff, storage.GetStuff ());
		}

		[Test]
		[Category("Ocurrence is saved")]
		public void TestOcurrenceIsSaved() {
			storage.SetOcurrence (ocurrence);
			storage.save ();
			Assert.AreEqual (ocurrence, storage.GetOcurrence ());
		}

	}
}