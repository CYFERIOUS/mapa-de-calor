using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Report Saver Tests")]
	internal class FormSaverTest {

		IFormDataSaver saver = new ReportSaver();
	
		IDataStorage storage;
		FormData data;

		string name = "name";
		string comments = "comments";
		Vector2 annotation = new Vector2(1,2);
		int timestamp = 1234567;
		string stuff = "article";
		int ocurrence = (int)Ocurrence.Assault;

		[SetUp]
		public void Setup(){
			CreateFormData ();
			storage = Substitute.For<IDataStorage>();
			saver.SetStorage (storage);
			saver.Save (data);
		}

		private void CreateFormData(){
			data = new FormData ();
			data.name = name;
			data.comments = comments;
			data.annotation = annotation;
			data.timestamp = timestamp;
			data.stuff = stuff;
			data.ocurrence = ocurrence;
		}

		[Test]
		[Category("Name is saved Test")]
		public void TestNameIsSaved() {
			storage.Received().SetName(name);
		}

		[Test]
		[Category("Comments are Saved Test")]
		public void TestCommentsIsSaved() {
			storage.Received().SetComments(comments);
		}

		[Test]
		[Category("Annotation is Saved Test")]
		public void TestAnnotationIsSaved() {
			storage.Received().SetAnnotation(annotation);
		}

		[Test]
		[Category("Timestamp is Saved")]
		public void TestTimestampIsSaved() {
			storage.Received().SetTimestamp(timestamp);
		}

		[Test]
		[Category("Article is Saved")]
		public void TestArticleIsSaved() {
			storage.Received().SetStuff(stuff);
		}

		[Test]
		[Category("Ocurrence is Saved")]
		public void TestRobberyIsSaved() {
			storage.Received().SetOcurrence(ocurrence);
		}

	}
}
