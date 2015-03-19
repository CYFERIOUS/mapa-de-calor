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
		protected FormData[] data;
		
		protected string name = "name";
		protected string comments = "comments";
		protected Vector2 annotation = new Vector2(1,2);
		protected int timestamp = 338498400;
		protected string stuff = "article";
		protected int ocurrence = (int)Ocurrence.Assault;
		protected int keyTotals;
		protected int numberOfFormData = 5;
		
		[SetUp]
		public void Setup(){
			CreateFormData (numberOfFormData);
			ConfigureSubstitue ();
			ConfigureAccessors ();
			saveData();
		}
		
		private void CreateFormData(int size) {
			keyTotals = size;
			data = new FormData[size];
			for(int id = 0;id < size; ++id)
				data[id] = generateForm(id);
		}

		FormData generateForm (int id) {
			FormData form = new FormData ();
			form.key = id;
			form.name = name + id;
			form.comments = comments + id;
			form.annotation = new Vector2((float)(annotation.x + id), (float)(annotation.y + id));
			form.timestamp = timestamp + id;
			form.stuff = stuff + id;
			form.ocurrence = ocurrence + id;
			return form;
		}
		
		private void ConfigureSubstitue () {
			storage = Substitute.For<IDataStorage>();
			storage.GetTotalKey ().Returns(keyTotals);

			for(int key = 0; key < keyTotals; ++key) {
				storage.GetName (key).Returns(data[key].name);
				storage.GetAnnotation (key).Returns(data[key].annotation);
				storage.GetComments (key).Returns(data[key].comments);
				storage.GetStuff (key).Returns(data[key].stuff);
				storage.GetTimestamp (key).Returns(data[key].timestamp);
				storage.GetOcurrence (key).Returns(data[key].ocurrence);
			}
		}

		void saveData () {
			for(int id = 0; id < keyTotals; ++id) {
				saver.SetKey(id);
				saver.Save (data[id]);
			}
		}

		private void ConfigureAccessors () {
			saver.SetStorage (storage);
			loader.SetStorage (storage);
		}

		[Test]
		[Category("Name is loaded")]
		public void TestNameIsLoaded() {
			for(int key = 0; key < keyTotals; ++key)
				Assert.AreEqual (data[key].name, loader.Load(key).name);
		}

		[Test]
		[Category("Annotation is loaded")]
		public void TestAnnotationIsLoaded() {
			for(int key = 0; key < keyTotals; ++key) {
				Assert.AreEqual (data[key].annotation.x, loader.Load(key).annotation.x);
				Assert.AreEqual (data[key].annotation.y, loader.Load(key).annotation.y);
			}
		}

		[Test]
		[Category("Comment is loaded")]
		public void TestCommentIsLoaded() {
			for(int key = 0; key < keyTotals; ++key)
				Assert.AreEqual (data[key].comments, loader.Load(key).comments);
		}
		[Test]
		[Category("Stuff is loaded")]
		public void TestStuffIsLoaded() {
			for(int key = 0; key < keyTotals; ++key)
				Assert.AreEqual (data[key].stuff, loader.Load(key).stuff);
		}

		[Test]
		[Category("Time is loaded")]
		public void TestTimeIsLoaded() {
			for(int key = 0; key < keyTotals; ++key)
				Assert.AreEqual (data[key].timestamp, loader.Load(key).timestamp);
		}

		[Test]
		[Category("Ocurrence is loaded")]
		public void TestOcurrenceIsLoaded() {
			for(int key = 0; key < keyTotals; ++key)
				Assert.AreEqual (data[key].ocurrence, loader.Load(key).ocurrence);
		}
	}
}
