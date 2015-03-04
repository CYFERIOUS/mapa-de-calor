using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Test ReportFormTest")]
	internal class FormSenderTest {

		public InputField place;

		[Test,Ignore]
		[Category("Test Inpunt")]
		public void TestIfInputCrimeIsRecieved() {
			ReportSender agent = new ReportSender ();
			Assert.AreEqual (agent.GetPlaceIpunt(), place.text);
		}
	}
}

