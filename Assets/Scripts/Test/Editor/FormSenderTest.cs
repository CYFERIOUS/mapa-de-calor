using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTest {
	[TestFixture]
	[Category("Test ReportFormTest")]
	internal class ReportFormTest {

		public InputField Crime;

		[Test]
		[Category("Test Inpunt")]
		public void TestIfInputCrimeIsRecieved() {
			ReportSender agent = new ReportSender ();
			Assert.AreEqual (agent.GetCrimeIpunt(), Crime.text);
		}
	}
}

