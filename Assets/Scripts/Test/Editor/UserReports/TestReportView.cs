using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using UnityEngine.UI;


namespace UnityTest {
	[TestFixture]
	[Category("Report View Tests")]
	internal class TestReportView : DataIOTestBase {

		private FormData dataPerUser;
		//private Text reporter;


		[SetUp]
		public void Setup(){
			int keyEst = loader.GetTotalKey();
			dataPerUser = new FormData();
		}
		
		[Test]
		[Category("Name is reported")]
		public void TestNameIsReceived() {
			dataPerUser = loader.Load(0);
			Assert.AreEqual(data[0].name,dataPerUser.name);
		}

	}
}

