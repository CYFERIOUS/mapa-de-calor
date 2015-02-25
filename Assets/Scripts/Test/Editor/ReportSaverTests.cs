using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest {
	[TestFixture]
	[Category("Report Saver Tests")]
	internal class ReportSaverTests {

		[Test]
		[Category("Initialization Test")]
		public void initializationTest() {
			ReportSaver saver = new ReportSaver ();

			Vector2 location = new Vector2 ();
			Assert.AreEqual (saver.getLocation().x, location.x);
			Assert.AreEqual (saver.getLocation().y, location.y);

			Assert.AreEqual (saver.getRobbery(), Robbery.non_specified);
		}
	}
}