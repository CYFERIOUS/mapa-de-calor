using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest {
	[TestFixture]
	[Category("Sample Tests")]
	internal class HealthSampleTests : MonoBehaviour {
		[Test]
		[Category("Failing Tests")]
		public void ExceptionTest()
		{
			HealthSample health = new HealthSample ();
			health.healthAmount = 50f;
			
			health.TakeDamage(10f);
			
			// assert (verify) that healthAmount was updated.
			Assert.AreEqual (40f, health.healthAmount);
		}
	}
}