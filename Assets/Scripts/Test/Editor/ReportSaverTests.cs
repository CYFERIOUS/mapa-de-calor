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

			Assert.AreEqual (saver.getRobbery(), (int)Robbery.non_specified);
		}

		[Test]
		[Category("PalyerPrefs Test")]
		public void playerPrefTest() {
			ReportSaver saver = new ReportSaver ();
			ReportSaver saverToCompare = new ReportSaver ();

			Vector2 location = new Vector2 ();
			location.x = 0.5854f;
			location.y = 98.77f;

			saver.setArticle ("Article test");
			saver.setComments ("Comment Test");
			saver.setUserName ("User Test");
			saver.setLocation (location);
			saver.setRobbery ((int)Robbery.Assault);
			saver.setTimeStamp (1254874);
		

			saver.save ();
			saverToCompare.load ();

			Assert.AreEqual (saver.getTimeStamp(), saverToCompare.getTimeStamp());
			Assert.AreEqual (saver.getUserName(), saverToCompare.getUserName());
			Assert.AreEqual (saver.getLocation().x, saverToCompare.getLocation().x);
			Assert.AreEqual (saver.getLocation().y, saverToCompare.getLocation().y);
			Assert.AreEqual (saver.getArticle(), saverToCompare.getArticle());
			Assert.AreEqual (saver.getComments(), saverToCompare.getComments());

		}
	}
}