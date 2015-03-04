using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest {
	[TestFixture]
	[Category("Test Category")]
	internal class TemplateTest {
		
		[Test]
		[Category("Sample Test")]
		public void SampleTest() {
			Assert.AreEqual (2, 1 + 1);
		}
	}
}
