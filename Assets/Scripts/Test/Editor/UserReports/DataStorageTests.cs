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
		int reportNo;
		string comments;
		Vector2 annotation;
		int timestamp;
		string stuff;
		int ocurrence;
		int numberOfSavedValues;
		int total;

		public const int NAME = 0;

		[SetUp]
		public void Setup() {
			storage = new PlayerPrefStorage();
			name = "name";
			reportNo = 1;
			comments = "comments";
			annotation = new Vector2(1,2);
			timestamp = 338498400;
			stuff = "article";
			ocurrence = (int)Ocurrence.Assault;
			numberOfSavedValues = 3;
		}

		[Test]
		[Category("Name is saved")]
		public void TestNameIsSaved() {
			for (int key = 0; key < numberOfSavedValues; ++key) {
				storage.SetName (key, name + key);
				storage.save ();
				Assert.AreEqual (name + key, storage.GetName (key));
			}
		}

		[Test]
		[Category("comments are saved")]
		public void TestCommentsAreSaved() {
			for (int key = 0; key < numberOfSavedValues; ++key) {
				storage.SetComments (key, comments + key);
				storage.save ();
				Assert.AreEqual (comments + key, storage.GetComments (key));
			}
		}

		[Test]
		[Category("Annotation is saved")]
		public void TestAnnotationIsSaved() {
			for (int key = 0; key < numberOfSavedValues; ++key) {
				annotation.x = (float)key;
				annotation.y = (float)(key * 2);
				storage.SetAnnotation (key, annotation);
				storage.save ();
				Assert.AreEqual ((float)key, storage.GetAnnotation(key).x);
				Assert.AreEqual ((float)(key * 2), storage.GetAnnotation(key).y);
			}
		}

		[Test]
		[Category("Timestamp is saved")]
		public void TestTimestampIsSaved() {
			for (int key = 0; key < numberOfSavedValues; ++key) {
				storage.SetTimestamp (key, timestamp + key);
				storage.save ();
				Assert.AreEqual (timestamp + key, storage.GetTimestamp (key));
			}
		}

		[Test]
		[Category("Stuff is saved")]
		public void TestStuffIsSaved() {
			for (int key = 0; key < numberOfSavedValues; ++key) {
				storage.SetStuff(key, stuff + key);
				storage.save ();
				Assert.AreEqual (stuff + key, storage.GetStuff (key));
			}
		}

		[Test]
		[Category("Ocurrence is saved")]
		public void TestOcurrenceIsSaved() {
			for (int key = 0; key < numberOfSavedValues; ++key) {
				storage.SetOcurrence (key, ocurrence + key);
				storage.save ();
				Assert.AreEqual (ocurrence + key, storage.GetOcurrence (key));
			}
		}
		[Test]
		[Category("total storage is saved")]
		public void TestTotalStorageIsSaved() {
			storage.SetTotalKey (total);
			storage.save ();
			Assert.AreEqual (total, storage.GetTotalKey());
		}

	}
}