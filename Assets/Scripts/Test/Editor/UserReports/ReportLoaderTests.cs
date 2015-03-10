/*using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {

	[TestFixture]
	[Category("Report Saver Tests")]
	internal class ReportLoaderTests : DataIOTestBase {

		[Test]
		[Category("Name is loaded")]
		public void TestNameIsLoaded() {
			Assert.AreEqual (name, LoadData().name);
		}
		[Test]
		[Category("Coordinates are loaded")]
		public void TestAnnotationIsLoaded() {
			Assert.AreEqual (annotation, LoadData().annotation);
		}

		private FormData LoadData() {
			return loader.Load ();
		}
	}
}*/