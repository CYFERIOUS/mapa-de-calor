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
			storage.SetKey (0);
			storage.Received().SetName(name);

		}

		[Test]
		[Category("Comments are Saved Test")]
		public void TestCommentsIsSaved() {
			storage.SetKey (0);
			storage.Received().SetComments(comments);
		}

		[Test]
		[Category("Annotation is Saved Test")]
		public void TestAnnotationIsSaved() {
			storage.SetKey (0);
			storage.Received().SetAnnotation(annotation);
		}

		[Test]
		[Category("Timestamp is Saved")]
		public void TestTimestampIsSaved() {
			storage.SetKey (0);
			storage.Received().SetTimestamp(timestamp);
		}

		[Test]
		[Category("Article is Saved")]
		public void TestArticleIsSaved() {
			storage.SetKey (0);
			storage.Received().SetStuff(stuff);
		}

		[Test]
		[Category("Ocurrence is Saved")]
		public void TestRobberyIsSaved() {
			storage.SetKey (0);
			storage.Received().SetOcurrence(ocurrence);
		}

	}
}
