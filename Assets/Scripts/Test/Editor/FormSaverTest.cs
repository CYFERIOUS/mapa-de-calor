using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest {
	[TestFixture]
	[Category("Report Saver Tests")]
	internal class FormSaverTest {

		IFormDataSaver saver = new FormSaverMock();
		IDataStorage storage = new DataStorageMock();
		FormData data = new FormData();

		string name = "name";
		string comments = "comments";
		Vector2 annotation = new Vector2(1,2);
		int timestamp = 1234567;
		string stuff = "article";
		int robbery = (int)Robbery.Assault;

		[SetUp]
		public void Setup(){
			saver.SetStorage (storage);
		}

		[Test]
		[Category("Name is saved Test")]
		public void TestNameIsSaved() {
			data.name = name;
			saver.Save (data);
			Assert.AreEqual (storage.GetName(),name);
		}

		[Test]
		[Category("Comments are Saved Test")]
		public void TestCommentsIsSaved() {
			data.comments = comments;
			saver.Save (data);
			Assert.AreEqual (storage.GetComments(),comments);
		}

		[Test]
		[Category("Annotation is Saved Test")]
		public void TestAnnotationIsSaved() {
			data.annotation = annotation;
			saver.Save (data);
			Assert.AreEqual (storage.GetAnnotation().x, annotation.x);
			Assert.AreEqual (storage.GetAnnotation().y, annotation.y);
		}

		[Test]
		[Category("Timestamp is Saved")]
		public void TestTimestampIsSaved() {
			data.timestamp = timestamp;
			saver.Save (data);
			Assert.AreEqual (storage.GetTimestamp(),timestamp);
		}

		[Test]
		[Category("Article is Saved")]
		public void TestArticleIsSaved() {
			data.stuff = stuff;
			saver.Save (data);
			Assert.AreEqual (storage.GetStuff(),stuff);
		}

		[Test]
		[Category("Robbery is Saved")]
		public void TestRobberyIsSaved() {
			data.robbery = robbery;
			saver.Save (data);
			Assert.AreEqual (storage.GetRobbery(),robbery);
		}

	}
}
