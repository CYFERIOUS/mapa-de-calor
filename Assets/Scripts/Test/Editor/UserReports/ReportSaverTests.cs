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
