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
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey (i);
				storage.SetName (name + storage.GetKey());
				storage.save ();
			}
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey(i);
				Assert.AreEqual (name + i, storage.GetName ());
			}
		}

		[Test]
		[Category("comments are saved")]
		public void TestCommentsAreSaved() {
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey (i);
				storage.SetComments (comments + storage.GetKey());
				storage.save ();
			}
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey(i);
				Assert.AreEqual (comments + i, storage.GetComments ());
			}
		}

		[Test]
		[Category("Annotation is saved")]
		public void TestAnnotationIsSaved() {
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey (i);
				annotation.x = (float)i;
				annotation.y = (float)(i * 2);
				storage.SetAnnotation (annotation);
				storage.save ();
			}
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey(i);
				Assert.AreEqual ((float)i, storage.GetAnnotation().x);
				Assert.AreEqual ((float)(i * 2), storage.GetAnnotation().y);
			}
		}

		[Test]
		[Category("Timestamp is saved")]
		public void TestTimestampIsSaved() {
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey (i);
				storage.SetTimestamp (timestamp + storage.GetKey());
				storage.save ();
			}
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey(i);
				Assert.AreEqual (timestamp + i, storage.GetTimestamp ());
			}
		}

		[Test]
		[Category("Stuff is saved")]
		public void TestStuffIsSaved() {
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey (i);
				storage.SetStuff(stuff + storage.GetKey());
				storage.save ();
			}
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey(i);
				Assert.AreEqual (stuff + i, storage.GetStuff ());
			}
		}

		[Test]
		[Category("Ocurrence is saved")]
		public void TestOcurrenceIsSaved() {
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey (i);
				storage.SetOcurrence (ocurrence + storage.GetKey());
				storage.save ();
			}
			for (int i = 0; i < numberOfSavedValues; ++i) {
				storage.SetKey(i);
				Assert.AreEqual (ocurrence + i, storage.GetOcurrence ());
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