using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Report Saver Tests")]
	internal class ReportSaverTests : DataIOTestBase {

		[Test]
		[Category("Name is saved Test")]
		public void TestNameIsSaved() {
			for(int key = 0; key < keyTotals; ++key)
				storage.Received().SetName(key, name);
		}

		[Test]
		[Category("Comments are Saved Test")]
		public void TestCommentsIsSaved() {
			for(int key = 0; key < keyTotals; ++key)
				storage.Received().SetComments(key, comments);
		}

		[Test]
		[Category("Annotation is Saved Test")]
		public void TestAnnotationIsSaved() {
			for(int key = 0; key < keyTotals; ++key)
				storage.Received().SetAnnotation(key, annotation);
		}

		[Test]
		[Category("Timestamp is Saved")]
		public void TestTimestampIsSaved() {
			for(int key = 0; key < keyTotals; ++key)
				storage.Received().SetTimestamp(key, timestamp);
		}

		[Test]
		[Category("Article is Saved")]
		public void TestArticleIsSaved() {
			for(int key = 0; key < keyTotals; ++key)
				storage.Received().SetStuff(key, stuff);
		}

		[Test]
		[Category("Ocurrence is Saved")]
		public void TestRobberyIsSaved() {
			for(int key = 0; key < keyTotals; ++key)
				storage.Received().SetOcurrence(key, ocurrence);
		}

	}
}
