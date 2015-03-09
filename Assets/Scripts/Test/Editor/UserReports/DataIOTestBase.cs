using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Data IO Test")]
	internal class DataIOTestBase {

		protected ReportSaver saver = new ReportSaver();
		protected ReportLoader loader = new ReportLoader();
		
		protected IDataStorage storage;
		protected FormData data;
		
		protected string name = "name";
		protected string comments = "comments";
		protected Vector2 annotation = new Vector2(1,2);
		protected int timestamp = 338498400;
		protected string stuff = "article";
		protected int ocurrence = (int)Ocurrence.Assault;
		
		[SetUp]
		public void Setup(){
			CreateFormData ();
			ConfigureSubstitue ();
			ConfigureAccessors ();
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

		private void ConfigureSubstitue ()
		{
			storage = Substitute.For<IDataStorage>();
			storage.GetName ().Returns(data.name);
			storage.GetAnnotation ().Returns(data.annotation);
			storage.GetComments ().Returns(data.comments);
			storage.GetStuff ().Returns(data.stuff);
			storage.GetTimestamp ().Returns(data.timestamp);
			storage.GetOcurrence ().Returns(data.ocurrence);
		}

		private void ConfigureAccessors ()
		{
			saver.SetStorage (storage);
			loader.SetStorage (storage);
		}
		[Test]
		[Category("Name is loaded")]
		public void TestNameIsLoaded() {
			Assert.AreEqual (name, loader.Load().name);
		}
		[Test]
		[Category("Annotation is loaded")]
		public void TestAnnotationIsLoaded() {
			Assert.AreEqual (annotation, loader.Load().annotation);
		}
		[Test]
		[Category("Comment is loaded")]
		public void TestCommentIsLoaded() {
			Assert.AreEqual (comments, loader.Load().comments);
		}
		[Test]
		[Category("Stuff is loaded")]
		public void TestStuffIsLoaded() {
			Assert.AreEqual (stuff, loader.Load().stuff);
		}
		[Test]
		[Category("Time is loaded")]
		public void TestTimeIsLoaded() {
			Assert.AreEqual (timestamp, loader.Load().timestamp);
		}
		[Test]
		[Category("Ocurrence is loaded")]
		public void TestOcurrenceIsLoaded() {
			Assert.AreEqual (ocurrence, loader.Load().ocurrence);
		}
	}
}
