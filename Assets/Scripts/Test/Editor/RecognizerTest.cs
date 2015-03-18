using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Map Recognizer Tests")]
	internal class RecognizerTest {


		public InputReader inputReader;
		public bool wascalled;
		InputGenerator generator;
		RayCastGenerator recognizer;

		[SetUp]
		public void SetUp(){
			inputReader = new InputReader ();
			generator = Substitute.For<InputGenerator> ();

			inputReader.SetGenerator (generator);
			recognizer = new RayCastGenerator ();
		}
		
		[Test]
		[Category("Recognizer Tests")]
		public void TestIfUserIsMakingTap() {
			generator.GeneratedTap ().Returns (true);
			inputReader.TapExecuted += HandleActionExecuted;
			AssertActionWasCalled ();
		}

		[Test]
		[Category("Recognizer Tests")]
		public void TestIfTapDetectsAnObject(){

			Assert.IsTrue (recognizer.ReturnsObject());
		}

		private void HandleActionExecuted() {
			wascalled = true;
		}
		
		private void AssertActionWasCalled(){
			inputReader.Update ();
			Assert.IsTrue(wascalled);
		}
	}
}
